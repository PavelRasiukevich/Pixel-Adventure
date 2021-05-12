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
            var _player = collision.gameObject.GetComponentInParent<BaseController>();

            if (_player)
            {
                var _velocity = _player.CharRb.velocity;
                _velocity.y = 0;
                _player.CharRb.velocity = _velocity;
                _player.CharRb.AddForce(new Vector2(_player.CharRb.velocity.x, pushForce), ForceMode2D.Impulse);
                anim.SetTrigger("Contact");
            }
        }
    }
}
