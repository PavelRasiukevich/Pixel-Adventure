using System;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseState : MonoBehaviour
    {
        public static int direction;

        protected static readonly int INT_STATE = Animator.StringToHash("State");

        #region Abstract Members
        public abstract StatesEnum State { get; }
        #endregion

        #region SerializeFields
        [SerializeField] protected LayerMask groundLayerMask;
        #endregion

        #region Components
        protected Rigidbody2D characterRigidBody;
        protected Animator characterAnimator;
        protected SpriteRenderer characterSpriteRenderer;
        protected BoxCollider2D characterBoxCollider;
        #endregion

        #region Properties
        public Action<StatesEnum> NextStateAction { get; set; }
        protected bool IsGrounded
        {
            get
            {
                return Physics2D.BoxCast(characterBoxCollider.bounds.center, characterBoxCollider.bounds.size,
                    0, Vector2.down, .1f, groundLayerMask);
            }
        }
        #endregion

        public void Setup(Rigidbody2D _charRb, Animator _charAnim, SpriteRenderer _charSr, BoxCollider2D _charBoxCollider)
        {
            characterRigidBody = _charRb;
            characterBoxCollider = _charBoxCollider;
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
