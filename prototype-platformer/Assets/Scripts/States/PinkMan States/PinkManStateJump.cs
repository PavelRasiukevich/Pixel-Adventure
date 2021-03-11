using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PinkManStateJump : PinkManBaseState
    {
        float h;

        public override void EntryState(PinkManController pink)
        {
            pink.State = StatesEnum.Jump;
            Jump(pink);
        }

        public override void FixedUpdate(PinkManController pink)
        {
            h = Input.GetAxis("Horizontal");

            if (pink.IsGrounded)
            {
                pink.TransitionToState(pink.DictionaryOfStates[StatesEnum.Idle]);
            }
        }

        public override void Update(PinkManController pink)
        {

        }

        private static void Jump(PinkManController pink)
        {
            pink.PinkRigidBody.velocity += Vector2.up * pink.JumpForce;
        }
    }
}
