using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SquareJumper : MonoBehaviour
    {

        [SerializeField] float pushForce;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _player = collision.gameObject.GetComponent<FrogController>();

            Debug.Log(_player);

            if (_player)
            {
                var _velocity = _player.CharRb.velocity;
                _velocity.y = 0;
            Debug.Log($"{_player.CharRb.velocity.y}");
                _player.CharRb.velocity = _velocity;

                _player.CharRb.velocity = new Vector2(_player.CharRb.velocity.x, pushForce);
            }
        }
    }
}
