using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class ShamanIdle : BaseState
    {
        public override CharacterState State => CharacterState.Idle;

        private void Update()
        {
            if (IsGrounded)
            {
                float _h = Input.GetAxis("Horizontal");
                float _jump = Input.GetAxis("Jump");

                if (Mathf.Abs(_h) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);

            }
            else
            {
                NextStateAction.Invoke(CharacterState.Fall);
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();
            direction = 0;
            characterRigidBody.velocity = Vector2.zero;
        }
    }
}
