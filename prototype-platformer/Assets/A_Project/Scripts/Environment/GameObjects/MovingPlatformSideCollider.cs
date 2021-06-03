using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PixelAdventure
{
    public class MovingPlatformSideCollider : MonoBehaviour
    {
        public Action ReachWall { get; set; }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            var _collision = collision.gameObject.GetComponent<Tilemap>();

            if (_collision)
            {
                ReachWall.Invoke();
            }
        }
    }
}
