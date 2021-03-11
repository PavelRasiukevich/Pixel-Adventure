using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PinkManStateIdle : PinkManBaseState
    {
        float h;
        float jump;

        public override void EntryState(PinkManController pink)
        {
            pink.State = StatesEnum.Idle;
            pink.PinkRigidBody.velocity = Vector2.zero;
        }

        public override void FixedUpdate(PinkManController pink)
        {
            h = Input.GetAxis("Horizontal");
            jump = Input.GetAxis("Jump");

            if (Mathf.Abs(h) > 0)
            {
                pink.TransitionToState(pink.DictionaryOfStates[StatesEnum.Move]);
            }
            else if (jump > 0)
            {
                pink.TransitionToState(pink.DictionaryOfStates[StatesEnum.Jump]);
            }
        }

        public override void Update(PinkManController pink)
        {

        }
    }
}
