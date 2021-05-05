using UnityEngine;

namespace PixelAdventure
{
    public class FrogMove : BaseState
    {

        public override CharacterState State => CharacterState.Move;

        private void FixedUpdate()
        {
            if (IsWatered)
                NextStateAction.Invoke(CharacterState.WaterFloat);

            if (IsGrounded)
            {
                if (Mathf.Abs(HorizontalAxes) > 0)
                {
                    characterRigidBody.velocity = new Vector2(HorizontalAxes * GameInfo.Instance.CharData.Speed, characterRigidBody.velocity.y);

                    if (JumpAxes > Mathf.Epsilon)
                    {
                        NextStateAction.Invoke(CharacterState.Jump);
                    }
                }
                else
                {
                    NextStateAction.Invoke(CharacterState.Idle);
                }

                if (characterRigidBody.velocity.x > 0)
                    transform.parent.parent.localScale = new Vector2(1, 1);
                else if (characterRigidBody.velocity.x < 0)
                    transform.parent.parent.localScale = new Vector2(-1, 1);
            }
            else
            {
                NextStateAction.Invoke(CharacterState.Fall);
            }
        }
    }
}
