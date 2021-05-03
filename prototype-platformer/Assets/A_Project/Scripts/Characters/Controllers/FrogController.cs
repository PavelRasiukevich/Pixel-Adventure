using PixelAdventure.Interfaces;
using System;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogController : BaseController
    {
        private new void Awake()
        {
            base.Awake();
            transform.position = SpawnPosition;
        }

        private new void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            var _collision = collision.GetComponent<IPowerUp>();

            if (_collision != null)
            {
                _collision.AddBonusValue(this);
            }
        }
    }
}
