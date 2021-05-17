using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogFastFall : BaseState
    {

        public override CharacterState State => CharacterState.FastFall;

        public Action FastFallUsed;

        private void FixedUpdate()
        {

            if (IsGrounded)
            {
                AudioManager.Instance.PlaySound(characterSounds.GroundedSound);

                if (Mathf.Abs(HorizontalAxes) > Mathf.Epsilon)
                    NextStateAction.Invoke(CharacterState.Move);
                else
                    NextStateAction.Invoke(CharacterState.Idle);
            }
        }

        public override void ActivateState()
        {
            base.ActivateState();
            FastFallUsed.Invoke();
            characterRigidBody.velocity = Vector2.zero;
            characterRigidBody.AddForce(Vector2.down * 100, ForceMode2D.Impulse);
        }
    }
}
