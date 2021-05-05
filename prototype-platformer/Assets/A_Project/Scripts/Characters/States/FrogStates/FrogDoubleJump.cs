using UnityEngine;

namespace PixelAdventure
{
    public class FrogDoubleJump : BaseState
    {

        public override CharacterState State => CharacterState.DoubleJump;

        private void FixedUpdate()
        {
            var _velocity_Y = characterRigidBody.velocity.y;

            if (_velocity_Y < 0)
                characterAnimator.SetInteger(INT_STATE, (int)CharacterState.Fall);

            if (IsWatered)
                NextStateAction.Invoke(CharacterState.WaterFloat);

            if (IsGrounded)
            {
                AudioManager.Instance.PlaySound(characterSounds.GroundedSound);

                if (Mathf.Abs(HorizontalAxes) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);
                else
                    NextStateAction.Invoke(CharacterState.Idle);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                NextStateAction.Invoke(CharacterState.FastFall);
        }



        public override void ActivateState()
        {
            base.ActivateState();

            AudioManager.Instance.PlaySound(characterSounds.DoubleJumpSound);

            if (characterRigidBody.velocity.y >= 0)
            {
                characterRigidBody.AddForce(Vector2.up * GameInfo.Instance.CharData.JumpForce, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 _velocity = characterRigidBody.velocity;
                _velocity.y = 0;
                characterRigidBody.velocity = _velocity;

                characterRigidBody.AddForce(Vector2.up * GameInfo.Instance.CharData.JumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
