using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PinkManStateMove : PinkManBaseState
    {
        float h;
        float jump;

        public override void EntryState(PinkManController pink)
        {
            pink.State = StatesEnum.Move;
        }

        public override void FixedUpdate(PinkManController pink)
        {
            h = Input.GetAxis("Horizontal");
            jump = Input.GetAxis("Jump");

            if (Mathf.Abs(h) > 0)
            {
                pink.PinkRigidBody.velocity = new Vector2(h * pink.Speed, pink.PinkRigidBody.velocity.y);

                if (jump > Mathf.Epsilon)
                    pink.TransitionToState(pink.DictionaryOfStates[StatesEnum.Jump]);
            }
            else
            {
                pink.TransitionToState(pink.DictionaryOfStates[StatesEnum.Idle]);
            }

            if (pink.PinkRigidBody.velocity.x > 0)
                pink.PinkSpriteRenderer.flipX = false;
            else if (pink.PinkRigidBody.velocity.x < 0)
                pink.PinkSpriteRenderer.flipX = true;
        }

        public override void Update(PinkManController pink)
        {

        }
    }
}
