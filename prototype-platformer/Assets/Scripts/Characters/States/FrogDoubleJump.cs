using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogDoubleJump : BaseState
    {
        [SerializeField] float jumpForce;

        public override StatesEnum State => StatesEnum.DoubleJump;

        private void FixedUpdate()
        {
            var _velocity_Y = frogRigidBody.velocity.y;

            if (_velocity_Y < 1)
                NextStateAction.Invoke(StatesEnum.Fall);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                NextStateAction.Invoke(StatesEnum.FastFall);
        }

        public override void ActivateState()
        {
            base.ActivateState();
            frogRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
