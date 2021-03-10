using UnityEngine;

namespace PixelAdventure
{
    public class NinjaStateMove : NinjaBaseState
    {
        float h;
        float jump;

        public override void EntryState(NinjaFrogController frog)
        {
            Debug.Log("MOVE");
            frog.State = StatesEnum.Move;
        }

        public override void FixedUpdate(NinjaFrogController frog)
        {

            h = Input.GetAxis("Horizontal");
            jump = Input.GetAxis("Jump");

            if (Mathf.Abs(h) > 0)
            {
                frog.FrogRigidBody.velocity = new Vector2(h * frog.Speed, frog.FrogRigidBody.velocity.y);

                if (jump > Mathf.Epsilon)
                    frog.TransitionToState(frog.DictionaryOfStates[StatesEnum.Jump]);
            }
            else
            {
                frog.TransitionToState(frog.DictionaryOfStates[StatesEnum.Idle]);
            }

            if (frog.FrogRigidBody.velocity.x > 0)
                frog.FrogSpriteRenderer.flipX = false;
            else if (frog.FrogRigidBody.velocity.x < 0)
                frog.FrogSpriteRenderer.flipX = true;

        }

        public override void Update(NinjaFrogController frog)
        {
        }
    }
}
