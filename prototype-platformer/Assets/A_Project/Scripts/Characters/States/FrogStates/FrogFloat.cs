using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogFloat : BaseState
    {
        public override CharacterState State => CharacterState.WaterFloat;

        [SerializeField] float speed;

        float h;

        private void FixedUpdate()
        {
            if (Mathf.Abs(h) > 0)
            {
                characterRigidBody.velocity = new Vector2(h * speed, characterRigidBody.velocity.y);

                if (Input.GetAxis("Jump") > Mathf.Epsilon)
                {
                    NextStateAction.Invoke(CharacterState.Jump);
                }
            }
        }

        private void Update()
        {
            h = Input.GetAxis("Horizontal");
        }

    }
}
