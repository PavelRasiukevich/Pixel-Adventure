using UnityEngine;

namespace PixelAdventure
{
    public class FrogDash : BaseState
    {
        public override CharacterState State => CharacterState.Dash;

        float timer;
        bool canDash;
        bool positive;

        private void OnEnable()
        {
            timer = GameInfo.Instance.CharData.DashDuration;
        }

        private void FixedUpdate()
        {

            if (canDash)
            {
                if (characterRigidBody.velocity.x > 0)
                {
                    positive = true;
                    characterRigidBody.AddForce(Vector2.right * GameInfo.Instance.CharData.DashForce, ForceMode2D.Impulse);
                }
                else if (characterRigidBody.velocity.x < 0)
                {
                    positive = false;
                    characterRigidBody.AddForce(-Vector2.right * GameInfo.Instance.CharData.DashForce, ForceMode2D.Impulse);
                }
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

            DisplayDashAfterImage();

        }

        private void DisplayDashAfterImage()
        {
            var _objectFromPool = ObjectPoolManager.Instance.GetObjectFromPool();

            _objectFromPool.SetActive(true);

            _objectFromPool.transform.position = transform.position;
            _objectFromPool.transform.rotation = transform.rotation;

            if (positive)
                _objectFromPool.transform.localScale = new Vector3(1, 1, 1);
            else
                _objectFromPool.transform.localScale = new Vector3(-1, 1, 1);
        }

        public override void ActivateState()
        {
            base.ActivateState();
            canDash = false;
        }

        public override void DeactivateState()
        {
            base.DeactivateState();
        }
    }
}
