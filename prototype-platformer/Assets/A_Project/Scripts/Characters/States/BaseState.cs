using System;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseState : MonoBehaviour
    {
        public static int direction;

        protected static readonly int INT_STATE = Animator.StringToHash("State");

        #region Abstract Members
        public abstract CharacterState State { get; }
        #endregion

        #region SerializeFields
        [SerializeField] protected LayerMask groundLayerMask;
        [SerializeField] protected float boxCastDistance;
        #endregion

        #region Components
        protected Rigidbody2D characterRigidBody;
        protected Animator characterAnimator;
        protected SpriteRenderer characterSpriteRenderer;
        protected CapsuleCollider2D charCapsuleCollider;
        #endregion

        #region Properties
        public Action<CharacterState> NextStateAction { get; set; }
        protected bool IsGrounded
        {
            get
            {
                return Physics2D.BoxCast(charCapsuleCollider.bounds.center,
                    new Vector2(charCapsuleCollider.bounds.extents.x, charCapsuleCollider.bounds.size.y - .1f),
                    0.0f, Vector2.down, 0.11f, groundLayerMask);
            }
        }
        #endregion

        public void Setup(Rigidbody2D _charRb, Animator _charAnim, SpriteRenderer _charSr, CapsuleCollider2D _charCapsuleCollider)
        {
            characterRigidBody = _charRb;
            charCapsuleCollider = _charCapsuleCollider;
            characterAnimator = _charAnim;
            characterSpriteRenderer = _charSr;
        }

        public void SetupRb(Rigidbody2D _charRb)
        {
            characterRigidBody = _charRb;
        }

        public virtual void ActivateState()
        {
            gameObject.SetActive(true);
            characterAnimator.SetInteger(INT_STATE, (int)State);
        }

        public virtual void DeactivateState()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnCollision(Collision2D collision)
        {
        }
    }
}
