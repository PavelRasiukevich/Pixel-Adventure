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
        [SerializeField] protected CharacterSoundSO characterSounds;
        #endregion

        #region Components
        protected Rigidbody2D characterRigidBody;
        protected Animator characterAnimator;
        protected SpriteRenderer characterSpriteRenderer;
        protected BoxCollider2D charBoxCollider;
        #endregion

        #region Properties
        public Action<CharacterState> NextStateAction { get; set; }
        public float HorizontalAxes
        {
            get => Input.GetAxis("Horizontal");
        }
        public float VerticalAxes
        {
            get => Input.GetAxis("Vertical");
        }
        public float JumpAxes
        {
            get => Input.GetAxis("Jump");
        }

        public float DashAxes
        {
            get => Input.GetAxis("Dash");
        }
        protected bool IsGrounded
        {
            get
            {
                return Physics2D.BoxCast(charBoxCollider.bounds.center,
                    new Vector2(charBoxCollider.bounds.size.x, charBoxCollider.bounds.size.y - .2f),
                    0.0f, Vector2.down, 0.21f, groundLayerMask);
            }
        }

        #endregion

        public void Setup(Rigidbody2D _charRb,
            Animator _charAnim, SpriteRenderer _charSr,
            BoxCollider2D _charBoxCollider, CharacterSoundSO _characterSounds)
        {
            characterSounds = _characterSounds;
            characterRigidBody = _charRb;
            charBoxCollider = _charBoxCollider;
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
    }
}
