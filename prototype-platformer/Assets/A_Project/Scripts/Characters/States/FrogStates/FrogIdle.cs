using UnityEngine;

namespace PixelAdventure
{
    public class FrogIdle : BaseState
    {
        public override CharacterState State => CharacterState.Idle;

        private void FixedUpdate()
        {
            if (IsWatered)
                NextStateAction.Invoke(CharacterState.WaterFloat);

            if (IsGrounded)
            {
                float _h = Input.GetAxis("Horizontal");
                float _jump = Input.GetAxis("Jump");

                if (Mathf.Abs(_h) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);

                if (_jump > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Jump);
            }
            else
            {
                NextStateAction.Invoke(CharacterState.Fall);
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();
            direction = 0;
            characterRigidBody.velocity = Vector2.zero;
        }
    }
}
