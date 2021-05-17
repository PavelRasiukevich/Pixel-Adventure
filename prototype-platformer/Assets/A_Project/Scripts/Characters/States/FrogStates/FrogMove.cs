using System;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogMove : BaseState
    {
        public override CharacterState State => CharacterState.Move;

        public Action PlayerUsedDash;

        private void FixedUpdate()
        {
            if (IsWatered)
                NextStateAction.Invoke(CharacterState.WaterFloat);

            if (IsGrounded)
            {
                if (Mathf.Abs(HorizontalAxes) > 0)
                {
                    characterRigidBody.velocity = new Vector2(HorizontalAxes * GameInfo.Instance.CharData.Speed, characterRigidBody.velocity.y);

                    if (DashAxes > Mathf.Epsilon)
                        if (GameInfo.Instance.CharData.HasDash)
                            if (GameInfo.Instance.CharData.HasReloadedDash)
                            {
                                NextStateAction(CharacterState.Dash);
                                PlayerUsedDash.Invoke();
                            }

                    if (JumpAxes > Mathf.Epsilon)
                        NextStateAction.Invoke(CharacterState.Jump);
                }
                else
                    NextStateAction.Invoke(CharacterState.Idle);

                SpriteFlipper.FlipSprite(characterRigidBody, characterSpriteRenderer);
            }
            else
                NextStateAction.Invoke(CharacterState.Fall);
        }

        public override void ActivateState()
        {
            base.ActivateState();
        }
    }
}
