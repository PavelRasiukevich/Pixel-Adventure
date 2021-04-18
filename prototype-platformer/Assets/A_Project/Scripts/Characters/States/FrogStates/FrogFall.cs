using UnityEngine;

namespace PixelAdventure
{
    public class FrogFall : BaseState
    {
        [SerializeField] float gravityMultiplyer;

        float jump;

        public override CharacterState State => CharacterState.Fall;
       
        public void FixedUpdate()
        {
            if (characterRigidBody.velocity.y < 0)
                characterRigidBody.velocity += Vector2.up * Physics2D.gravity * gravityMultiplyer * Time.deltaTime;

            if (jump > Mathf.Epsilon)
                NextStateAction.Invoke(CharacterState.Jump);

            if (IsGrounded)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);
                else
                    NextStateAction.Invoke(CharacterState.Idle);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                NextStateAction.Invoke(CharacterState.FastFall);

            jump = Input.GetAxis("Jump");
        }
    }
}
