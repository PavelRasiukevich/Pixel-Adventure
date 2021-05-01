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

            var _bonus = collision.gameObject.GetComponent<BaseBonus>();

            if (_bonus)
            {
                switch (_bonus.BonusName)
                {
                    case "JumpBonus":
                        charStats.JumpForce += _bonus.AddBonus();
                        Destroy(_bonus.gameObject);
                        break;
                }
            }
        }
    }
}
