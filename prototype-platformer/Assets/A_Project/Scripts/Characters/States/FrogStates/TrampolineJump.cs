using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class TrampolineJump : BaseState
    {
        public override CharacterState State => CharacterState.TrampolineJump;

        [SerializeField] float pushForce;

        private void FixedUpdate()
        {
            if (characterRigidBody.velocity.y < 0)
                NextStateAction(CharacterState.Fall);

            if (JumpAxes > Mathf.Epsilon)
                NextStateAction.Invoke(CharacterState.DoubleJump);

            if (Mathf.Abs(HorizontalAxes) > 0)
                characterRigidBody.velocity = new Vector2(HorizontalAxes * GameInfo.Instance.CharData.Speed, characterRigidBody.velocity.y);

            SpriteFlipper.FlipSprite(characterRigidBody, characterSpriteRenderer);
        }

        public override void ActivateState()
        {
            base.ActivateState();
            characterRigidBody.velocity = Vector2.zero;
            characterRigidBody.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
        }
    }
}
