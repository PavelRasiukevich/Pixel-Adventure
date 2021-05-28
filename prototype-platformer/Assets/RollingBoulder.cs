using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class RollingBoulder : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _player = collision.gameObject.GetComponent<BaseController>();

            if (_player)
            {
                _player.OnNextStateRequest(CharacterState.Die);
            }
        }
    }
}
