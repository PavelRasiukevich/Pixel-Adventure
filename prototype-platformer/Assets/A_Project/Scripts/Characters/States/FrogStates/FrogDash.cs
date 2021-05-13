using UnityEngine;

namespace PixelAdventure
{
    public class FrogDash : BaseState
    {
        public override CharacterState State => CharacterState.Dash;

        float timer;

        private void OnEnable()
        {
            timer = GameInfo.Instance.CharData.DashDuration;
        }

        private void Update()
        {
            if (timer <= 0)
            {
                NextStateAction(CharacterState.Idle);
            }
            else
            {
                timer -= Time.deltaTime;

                if (characterRigidBody.velocity.x > 0)
                    characterRigidBody.AddForce(Vector2.right * GameInfo.Instance.CharData.DashForce, ForceMode2D.Impulse);
                else if (characterRigidBody.velocity.x < 0)
                    characterRigidBody.AddForce(-Vector2.right * GameInfo.Instance.CharData.DashForce, ForceMode2D.Impulse);
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();

        }
    }
}
