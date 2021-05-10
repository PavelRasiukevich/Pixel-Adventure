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
                            if (GameInfo.Instance.HasReloadedDash)
                            {
                                PlayerUsedDash.Invoke();
                                NextStateAction(CharacterState.Dash);
                            }

                    if (JumpAxes > Mathf.Epsilon)
                        NextStateAction.Invoke(CharacterState.Jump);
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

        public override void ActivateState()
        {
            base.ActivateState();
        }
    }
}
