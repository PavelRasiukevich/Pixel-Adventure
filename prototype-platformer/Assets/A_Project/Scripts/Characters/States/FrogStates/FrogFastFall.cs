using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogFastFall : BaseState
    {
        [SerializeField] float fallForce;

        public override StatesEnum State => StatesEnum.FastFall;

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
            characterRigidBody.velocity = Vector2.zero;
            characterRigidBody.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);
        }
    }
}
