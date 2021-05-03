using UnityEngine;

namespace PixelAdventure
{
    public class FrogJump : BaseState
    {
        [SerializeField] float doubleJumpCountDown;

        bool IsSecondJumpAvaliable
        {
            get
            {
                if (timer < 0)
                    return true;

                return false;
            }
        }

        private float timer;

        private void OnEnable()
        {
            timer = doubleJumpCountDown;
        }

        public override CharacterState State => CharacterState.Jump;

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
            timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.S))
                NextStateAction.Invoke(CharacterState.FastFall);

            if (IsSecondJumpAvaliable)
                if (Input.GetKeyDown(KeyCode.Space))
                    NextStateAction.Invoke(CharacterState.DoubleJump);

        }

        public override void ActivateState()
        {
            base.ActivateState();

            AudioManager.Instance.PlaySound(characterSounds.JumpSound);

            if (characterRigidBody.velocity.y >= 0)
            {
                characterRigidBody.AddForce(Vector2.up * charStats.CurrentJumpForce, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 _velocity = characterRigidBody.velocity;
                _velocity.y = 0;
                characterRigidBody.velocity = _velocity;

                characterRigidBody.AddForce(Vector2.up * charStats.CurrentJumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
