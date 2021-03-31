using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PinkyFall : BaseState
    {
        public override StatesEnum State => StatesEnum.Fall;

        [SerializeField] float floatingSpeed;

        float h;

        public void FixedUpdate()
        {
            if (Mathf.Abs(h) > Mathf.Epsilon)
                characterRigidBody.velocity = new Vector2(h * floatingSpeed, -2.5f);

            if (IsGrounded)
            {
                if (Mathf.Abs(h) > Mathf.Epsilon)
                    NextStateAction.Invoke(StatesEnum.Move);
                else
                    NextStateAction.Invoke(StatesEnum.Idle);
            }
        }

        private void Update()
        {
            h = Input.GetAxis("Horizontal");
        }
    }
}
