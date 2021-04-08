using UnityEngine;

namespace PixelAdventure
{
    public class PinkyMove : BaseState
    {
        [SerializeField] float speed;

        public override StatesEnum State => StatesEnum.Move;

        private void FixedUpdate()
        {
            if (IsGrounded)
            {
                float _h = Input.GetAxis("Horizontal");
                float _jump = Input.GetAxis("Jump");

                if (_h > 0)
                    direction = 1;
                else if (_h < 0)
                    direction = -1;

                if (Mathf.Abs(_h) > 0)
                {
                    characterRigidBody.velocity = new Vector2(_h * speed, characterRigidBody.velocity.y);

                    if (_jump > Mathf.Epsilon)
                        NextStateAction.Invoke(StatesEnum.Jump);
                }
                else
                {
                    NextStateAction.Invoke(StatesEnum.Idle);
                }

                if (characterRigidBody.velocity.x > 0)
                    transform.parent.parent.localScale = new Vector2(direction, 1);
                else if (characterRigidBody.velocity.x < 0)
                    transform.parent.parent.localScale = new Vector2(direction, 1);
            }
            else
            {
                NextStateAction.Invoke(StatesEnum.Float);
            }
        }
    }
}
