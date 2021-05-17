using UnityEngine;

namespace PixelAdventure
{
    public class FrogFall : BaseState
    {
        [SerializeField] float gravityMultiplyer;

        public override CharacterState State => CharacterState.Fall;

        public void FixedUpdate()
        {
            if (characterRigidBody.velocity.y < 0)
                characterRigidBody.velocity += Vector2.up * Physics2D.gravity * gravityMultiplyer * Time.deltaTime;

            if (JumpAxes > Mathf.Epsilon)
                NextStateAction.Invoke(CharacterState.Jump);
            
            if (IsGrounded)
            {
                AudioManager.Instance.PlaySound(characterSounds.GroundedSound);

                if (Mathf.Abs(HorizontalAxes) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);
                else
                    NextStateAction.Invoke(CharacterState.Idle);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                if (GameInfo.Instance.CharData.HasFastFall && GameInfo.Instance.CharData.HasReloadedFastFall)
                    NextStateAction.Invoke(CharacterState.FastFall);
        }
    }
}
