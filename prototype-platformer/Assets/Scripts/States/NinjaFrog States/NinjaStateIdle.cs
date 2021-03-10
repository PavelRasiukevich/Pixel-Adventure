using UnityEngine;

namespace PixelAdventure
{
    public class NinjaStateIdle : NinjaBaseState
    {
        float h;
        float jump;

        public override void EntryState(NinjaFrogController frog)
        {
            Debug.Log("IDLE");

            frog.State = StatesEnum.Idle;
            frog.FrogRigidBody.velocity = Vector2.zero;
        }

        public override void FixedUpdate(NinjaFrogController frog)
        {

            h = Input.GetAxis("Horizontal");
            jump = Input.GetAxis("Jump");

            if (Mathf.Abs(h) > 0)
            {
                frog.TransitionToState(frog.DictionaryOfStates[StatesEnum.Move]);
            }
            else if (jump > 0)
            {
                frog.TransitionToState(frog.DictionaryOfStates[StatesEnum.Jump]);
            }

        }

        public override void Update(NinjaFrogController frog)
        {
        }
    }
}
