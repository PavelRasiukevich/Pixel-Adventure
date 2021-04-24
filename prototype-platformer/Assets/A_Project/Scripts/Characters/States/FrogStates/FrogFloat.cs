using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogFloat : BaseState
    {
        public override CharacterState State => CharacterState.WaterFloat;

        [SerializeField] float speed;

        private void FixedUpdate()
        {
            if (Mathf.Abs(HorizontalAxes) > 0)
            {
                characterRigidBody.velocity = new Vector2(HorizontalAxes * speed, characterRigidBody.velocity.y);

                if (JumpAxes > Mathf.Epsilon)
                {
                    NextStateAction.Invoke(CharacterState.Jump);
                }
            }
        }
    }
}
