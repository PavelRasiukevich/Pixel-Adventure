using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class RollingBall : MonoBehaviour, IDamaging
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var _deathSurface = collision.GetComponent<Obstacle>();

            if (_deathSurface)
                Destroy(gameObject);
        }
    }
}
