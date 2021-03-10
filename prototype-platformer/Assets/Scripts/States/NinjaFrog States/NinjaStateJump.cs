using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class NinjaStateJump : NinjaBaseState
    {

        float h;

        public override void EntryState(NinjaFrogController frog)
        {
            Debug.Log("JUMP");
            frog.State = StatesEnum.Jump;
            Jump(frog);
        }

        public override void FixedUpdate(NinjaFrogController frog)
        {
            h = Input.GetAxis("Horizontal");

            if (frog.IsGrounded)
            {
                frog.TransitionToState(frog.DictionaryOfStates[StatesEnum.Idle]);
            }

        }

        public override void Update(NinjaFrogController frog)
        {
        }

        private static void Jump(NinjaFrogController frog)
        {
            frog.FrogRigidBody.velocity += Vector2.up * frog.JumpForce;
        }
    }
}
