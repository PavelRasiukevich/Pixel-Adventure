using UnityEngine;

namespace PixelAdventure
{
    public class PinkyFloat : BaseState
    {
        [SerializeField] float floatingSpeed;
        [SerializeField] float floatingSpeedMultiplyer;
        [SerializeField] float speed;

        private float h;

        public override StatesEnum State => StatesEnum.Float;

        private void FixedUpdate()
        {
            if (Mathf.Abs(h) > Mathf.Epsilon)
                characterRigidBody.velocity = new Vector2(h * Mathf.Abs(speed), -floatingSpeed);
            else
                characterRigidBody.velocity = new Vector2(speed * direction, -floatingSpeed * floatingSpeedMultiplyer);

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
            h = Input.GetAxis("Horizontal");

            if (h > 0)
                direction = 1;
            else if (h < 0)
                direction = -1;

            if (characterRigidBody.velocity.x > 0)
                transform.parent.parent.localScale = new Vector2(direction, 1);
            else if (characterRigidBody.velocity.x < 0)
                transform.parent.parent.localScale = new Vector2(direction, 1);
        }
    }
}
