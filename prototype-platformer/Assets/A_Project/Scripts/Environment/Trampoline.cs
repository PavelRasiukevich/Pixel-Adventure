using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] float pushForce;

        Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _player = collision.gameObject.GetComponent<BaseController>();

            if (_player)
            {
                _player.CharRb.velocity = new Vector2(_player.CharRb.velocity.x, pushForce);
            }

            anim.SetTrigger("Contact");
        }
    }
}
