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
            timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.S))
                if (GameInfo.Instance.CharData.HasFastFall && GameInfo.Instance.CharData.HasReloadedFastFall)
                    NextStateAction.Invoke(CharacterState.FastFall);

            if (IsSecondJumpAvaliable)
                if (Input.GetKeyDown(KeyCode.Space))
                    if (GameInfo.Instance.CharData.HasDoubleJump && GameInfo.Instance.CharData.HasReloadedDoubleJump)
                        NextStateAction.Invoke(CharacterState.DoubleJump);

        }

        public override void ActivateState()
        {
            base.ActivateState();

            AudioManager.Instance.PlaySound(characterSounds.JumpSound);

            if (characterRigidBody.velocity.y >= 0)
                characterRigidBody.AddForce(Vector2.up * GameInfo.Instance.CharData.JumpForce, ForceMode2D.Impulse);
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
