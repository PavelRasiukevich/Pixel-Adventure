using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogMove : BaseState
    {
        [SerializeField] float speed;

        public override StatesEnum State => StatesEnum.Move;

        private void FixedUpdate()
        {
            if (IsGrounded)
            {
                float _h = Input.GetAxis("Horizontal");
                float _jump = Input.GetAxis("Jump");

                if (Mathf.Abs(_h) > 0)
                {
                    frogRigidBody.velocity = new Vector2(_h * speed, frogRigidBody.velocity.y);

                    if (_jump > Mathf.Epsilon)
                        NextStateAction.Invoke(StatesEnum.Jump);
                }
                else
                {
                    NextStateAction.Invoke(StatesEnum.Idle);
                }

                if (frogRigidBody.velocity.x > 0)
                    frogSpriteRenderer.flipX = false;
                else if (frogRigidBody.velocity.x < 0)
                    frogSpriteRenderer.flipX = true;
            }
            else
            {
                Debug.Log("Falling");
               NextStateAction.Invoke(StatesEnum.Fall);
            }

        }
    }
}
