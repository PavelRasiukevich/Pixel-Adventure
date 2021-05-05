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
            transform.position = GameInfo.Instance.UserData.PlayerSpawnPosition;
        }

        private new void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            var _powerUp = collision.GetComponent<IPowerUp>();
            var _ability = collision.GetComponent<IAbility>();

            if (_ability != null)
                _ability.AddAbility(this);

            if (_powerUp != null)
                _powerUp.AddBonusValue(this);
        }
    }
}
