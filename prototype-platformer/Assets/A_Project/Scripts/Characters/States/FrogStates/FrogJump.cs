using UnityEngine;

namespace PixelAdventure
{
    public class FrogJump : BaseState
    {
        [SerializeField] float jumpForce;
        [SerializeField] float doubleJumpCountDown;

        private float timer;

        private void OnEnable()
        {
            timer = doubleJumpCountDown;
        }

        public override StatesEnum State => StatesEnum.Jump;

        private void FixedUpdate()
        {
            var _velocity_Y = characterRigidBody.velocity.y;

            if (_velocity_Y < 0)
                characterAnimator.SetInteger(INT_STATE, (int)StatesEnum.Fall);

            if (IsGrounded)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
                    NextStateAction.Invoke(StatesEnum.Move);
                else
                    NextStateAction.Invoke(StatesEnum.Idle);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                NextStateAction.Invoke(StatesEnum.FastFall);

            if (IsSecondJumpAvaliable())
                if (Input.GetKeyDown(KeyCode.Space))
                    NextStateAction.Invoke(StatesEnum.DoubleJump);
        }

        private bool IsSecondJumpAvaliable()
        {
            timer -= Time.deltaTime;

            if (timer < 0)
                return true;

            return false;
        }

        public override void ActivateState()
        {
            base.ActivateState();
            characterRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
