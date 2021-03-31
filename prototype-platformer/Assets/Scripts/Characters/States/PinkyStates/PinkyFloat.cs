using System.Collections;
using System.Collections.Generic;
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
                characterRigidBody.velocity = Vector2.up * -floatingSpeed * floatingSpeedMultiplyer;

            if (IsGrounded)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
                    NextStateAction.Invoke(StatesEnum.Move);
                else
                    NextStateAction.Invoke(StatesEnum.Idle);
            }

            if (characterRigidBody.velocity.x > 0)
                transform.root.localScale = new Vector2(1, 1);
            else if (characterRigidBody.velocity.x < 0)
                transform.root.localScale = new Vector2(-1, 1);
        }

        private void Update()
        {
            h = Input.GetAxis("Horizontal");
        }

        public override void ActivateState()
        {
            base.ActivateState();
        }
    }
}
