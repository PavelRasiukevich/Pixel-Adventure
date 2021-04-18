using UnityEngine;

namespace PixelAdventure
{
    public class ShamanMove : BaseState
    {
        [SerializeField] float speed;

        public override CharacterState State => CharacterState.Move;

        private void FixedUpdate()
        {
            if (IsGrounded)
            {
                float _h = Input.GetAxis("Horizontal");
                float _jump = Input.GetAxis("Jump");

                if (Mathf.Abs(_h) > 0)
                {
                    characterRigidBody.velocity = new Vector2(_h * speed, characterRigidBody.velocity.y);
                }
                else
                {
                    NextStateAction.Invoke(CharacterState.Idle);
                }

                if (characterRigidBody.velocity.x > 0)
                    transform.parent.parent.localScale = new Vector2(1, 1);
                else if (characterRigidBody.velocity.x < 0)
                    transform.parent.parent.localScale = new Vector2(-1, 1);
            }
            else
            {
                NextStateAction.Invoke(CharacterState.Fall);
            }
        }
    }
}
