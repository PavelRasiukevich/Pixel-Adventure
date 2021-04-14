using UnityEngine;

namespace PixelAdventure
{
    public class FrogFall : BaseState
    {
        [SerializeField] float gravityMultiplyer;

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
            if (Input.GetKeyDown(KeyCode.S))
                NextStateAction.Invoke(StatesEnum.FastFall);

        }
    }
}
