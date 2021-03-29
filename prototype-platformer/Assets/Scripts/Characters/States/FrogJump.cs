using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogJump : BaseState
    {
        [SerializeField] float jumpForce;

        public override StatesEnum State => StatesEnum.Jump;

        private void FixedUpdate()
        {
            if (IsGrounded)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
                    NextStateAction.Invoke(StatesEnum.Move);
                else
                    NextStateAction.Invoke(StatesEnum.Idle);
            }

        }

        public override void ActivateState()
        {
            base.ActivateState();
            frogRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
