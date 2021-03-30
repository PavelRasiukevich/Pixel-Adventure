using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseState : MonoBehaviour
    {
        #region Abstract Members
        public abstract StatesEnum State { get; }
        #endregion

        static readonly int INT_STATE = Animator.StringToHash("State");

        #region SerializeFields
        [SerializeField] protected LayerMask groundLayerMask;
        #endregion

        #region Components
        protected Rigidbody2D frogRigidBody;
        protected Animator frogAnimator;
        protected SpriteRenderer frogSpriteRenderer;
        protected BoxCollider2D frogBoxCollider;
        #endregion

        #region Properties
        public Action<StatesEnum> NextStateAction { get; set; }
        protected bool IsGrounded
        {
            get
            {
                return Physics2D.BoxCast(frogBoxCollider.bounds.center, frogBoxCollider.bounds.size,
                    0, Vector2.down, .1f, groundLayerMask);
            }
        }
        #endregion

        public void Setup(Rigidbody2D _frogRb, Animator _frogAnimator, SpriteRenderer _frogSpriteRenderer, BoxCollider2D _boxCollider)
        {
            frogRigidBody = _frogRb;
            frogBoxCollider = _boxCollider;
            frogAnimator = _frogAnimator;
            frogSpriteRenderer = _frogSpriteRenderer;
        }

        public virtual void ActivateState()
        {
            gameObject.SetActive(true);
            frogAnimator.SetInteger(INT_STATE, (int)State);
        }

        public virtual void DeactivateState()
        {
            gameObject.SetActive(false);
        }

        public virtual void  OnCollision(Collision2D collision)
        {
           
        }
    }
}
