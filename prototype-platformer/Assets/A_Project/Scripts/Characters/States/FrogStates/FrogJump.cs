using UnityEngine;

namespace PixelAdventure
{
    public class FrogJump : BaseState
    {
        [SerializeField] float jumpForce;
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

        float jump;

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
                Debug.Log("Ground Detected in Jump!");
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
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

            jump = Input.GetAxis("Jump");
        }

        public override void ActivateState()
        {
            base.ActivateState();

            if (characterRigidBody.velocity.y >= 0)
            {
                characterRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 _velocity = characterRigidBody.velocity;
                _velocity.y = 0;
                characterRigidBody.velocity = _velocity;

                characterRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
