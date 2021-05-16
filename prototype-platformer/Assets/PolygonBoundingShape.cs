using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PolygonBoundingShape : MonoBehaviour
    {
        PolygonCollider2D col;

        private void Awake()
        {
            col = GetComponent<PolygonCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var _player = collision.GetComponentInParent<BaseController>();

            Debug.Log(_player);
            Debug.Log(col);


            if (_player)
            {
                _player.ExiteFromBoundingShape.Invoke(col);
            }
        }
    }
}
