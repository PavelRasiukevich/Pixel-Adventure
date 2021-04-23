using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Projectile : MonoBehaviour, IDamaging
    {
        [SerializeField] float force;

        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, 1f);
        }

        public void Move(Direction _direction)
        {
            switch (_direction)
            {
                case Direction.Right:
                    rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                    break;
                case Direction.Left:
                    rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                    break;
            }
        }
    }
}
