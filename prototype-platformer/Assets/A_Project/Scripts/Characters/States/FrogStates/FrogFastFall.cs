using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogFastFall : BaseState
    {
        [SerializeField] float fallForce;

        public override CharacterState State => CharacterState.FastFall;

        private void FixedUpdate()
        {
            if (IsWatered)
                NextStateAction.Invoke(CharacterState.WaterFloat);

            if (IsGrounded)
            {
                if (Mathf.Abs(HorizontalAxes) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);
                else
                    NextStateAction.Invoke(CharacterState.Idle);
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();
            characterRigidBody.velocity = Vector2.zero;
            characterRigidBody.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);
        }
    }
}
