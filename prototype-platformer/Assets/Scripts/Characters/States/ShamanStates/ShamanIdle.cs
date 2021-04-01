using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class ShamanIdle : BaseState
    {
        public override StatesEnum State => StatesEnum.Idle;

        private void Update()
        {
            if (IsGrounded)
            {
                float _h = Input.GetAxis("Horizontal");
                float _jump = Input.GetAxis("Jump");

                if (Mathf.Abs(_h) > Mathf.Epsilon)
                    NextStateAction.Invoke(StatesEnum.Move);

            }
            else
            {
                NextStateAction.Invoke(StatesEnum.Fall);
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();
            characterRigidBody.velocity = Vector2.zero;
        }
    }
}
