using UnityEngine;

namespace PixelAdventure
{
    public class ShamanFall : BaseState
    {
        [SerializeField] float gravityMultiplyer;
        [SerializeField] float speed;

        private float h;

        public override StatesEnum State => StatesEnum.Fall;

        public void FixedUpdate()
        {
            if (characterRigidBody.velocity.y < 0)
                characterRigidBody.velocity += Vector2.up * Physics2D.gravity * gravityMultiplyer * Time.deltaTime;

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
                transform.root.localScale = new Vector2(1, 1);
            if (h < 0)
                transform.root.localScale = new Vector2(-1, 1);
        }
    }
}
