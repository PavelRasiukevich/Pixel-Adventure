using UnityEngine;

namespace PixelAdventure
{
    public class FrogDash : BaseState
    {
        public override CharacterState State => CharacterState.Dash;

        float timer;
        bool canDash;

        private void OnEnable()
        {
            timer = GameInfo.Instance.CharData.DashDuration;
        }

        private void FixedUpdate()
        {

            if (canDash)
            {
                if (characterRigidBody.velocity.x > 0)
                    characterRigidBody.AddForce(Vector2.right * GameInfo.Instance.CharData.DashForce, ForceMode2D.Impulse);
                else if (characterRigidBody.velocity.x < 0)
                    characterRigidBody.AddForce(-Vector2.right * GameInfo.Instance.CharData.DashForce, ForceMode2D.Impulse);
            }
        }

        private void Update()
        {
            if (timer <= 0)
            {
                characterRigidBody.velocity = Vector2.zero;
                NextStateAction(CharacterState.Move);
            }
            else
            {
                timer -= Time.deltaTime;
                canDash = true;
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();
            canDash = false;
            charTrailRenderer.gameObject.SetActive(true);
        }

        public override void DeactivateState()
        {
            base.DeactivateState();
            charTrailRenderer.gameObject.SetActive(false);
        }
    }
}
