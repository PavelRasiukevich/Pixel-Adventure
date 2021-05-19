using System;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogDoubleJump : BaseState
    {

        public override CharacterState State => CharacterState.DoubleJump;

        public Action DoubleJumpUsed;

        private void FixedUpdate()
        {
            var _velocity_Y = characterRigidBody.velocity.y;

            if (_velocity_Y < 0)
                characterAnimator.SetInteger(INT_STATE, (int)CharacterState.Fall);

            if (IsGrounded)
            {
                AudioManager.Instance.PlaySound(characterSounds.GroundedSound);

                if (Mathf.Abs(HorizontalAxes) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);
                else
                    NextStateAction.Invoke(CharacterState.Idle);
            }

            if (Mathf.Abs(HorizontalAxes) > 0)
                characterRigidBody.velocity = new Vector2(HorizontalAxes * GameInfo.Instance.CharData.Speed, characterRigidBody.velocity.y);

            SpriteFlipper.FlipSprite(characterRigidBody, characterSpriteRenderer);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                if (GameInfo.Instance.CharData.HasFastFall && GameInfo.Instance.CharData.HasReloadedFastFall)
                    NextStateAction.Invoke(CharacterState.FastFall);
        }



        public override void ActivateState()
        {
            base.ActivateState();

            DoubleJumpUsed.Invoke();

            AudioManager.Instance.PlaySound(characterSounds.DoubleJumpSound);

            if (characterRigidBody.velocity.y >= 0)
                characterRigidBody.AddForce(Vector2.up * RecalculateJumpForce(), ForceMode2D.Impulse);
            else
            {
                Vector2 _velocity = characterRigidBody.velocity;

                _velocity.y = 0;
                characterRigidBody.velocity = _velocity;

                characterRigidBody.AddForce(Vector2.up * RecalculateJumpForce(), ForceMode2D.Impulse);
            }
        }

        public float RecalculateJumpForce()
        {
            var _value = GameInfo.Instance.CharData.JumpForce;
            var _recalculated = _value * 0.75f;

            return _recalculated;
        }
    }
}
