using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SlimeProjectile : MonoBehaviour
    {
        [SerializeField] float deathTime;

        Rigidbody2D slimeRb;

        private void Awake()
        {
            slimeRb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, deathTime);
        }

        public void SetPosition(Vector2 _pos)
        {
            transform.position = _pos;
            transform.rotation = Quaternion.identity;
        }

        public void AddForce(float _value)
        {
            slimeRb.AddForce(Vector2.up * _value, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var _player = collision.GetComponentInParent<BaseController>();

            if (_player)
            {
                _player.OnNextStateRequest(CharacterState.Die);
            }
        }
    }
}
