using UnityEngine;

namespace PixelAdventure
{
    public class PinkyJump : BaseState
    {
        [SerializeField] float jumpForce;
        [SerializeField] float gravityMultiplyer;

        public override StatesEnum State => StatesEnum.Jump;

        private void FixedUpdate()
        {
            var _velocity_Y = characterRigidBody.velocity.y;

            if (_velocity_Y < 0)
                NextStateAction.Invoke(StatesEnum.Float);

            if (characterRigidBody.velocity.y > 0 && Input.GetAxis("Jump") <= 0)
                characterRigidBody.velocity += Vector2.up * Physics2D.gravity.y * gravityMultiplyer * Time.deltaTime;

            if (IsGrounded)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
                    NextStateAction.Invoke(StatesEnum.Move);
                else
                    NextStateAction.Invoke(StatesEnum.Idle);
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();
            characterRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
