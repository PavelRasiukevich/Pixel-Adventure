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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var _player = collision.gameObject.GetComponentInParent<BaseController>();

            if (_player)
            {
                _player.CharRb.AddForce(new Vector2(_player.CharRb.velocity.x, pushForce), ForceMode2D.Impulse);
                anim.SetTrigger("Contact");
            }
        }
    }
}
