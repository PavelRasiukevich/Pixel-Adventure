using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class PosionSurface : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var _player = collision.gameObject.GetComponent<BaseController>();

            Debug.Log(_player);

            if (_player)
            {
                _player.OnNextStateRequest(CharacterState.Die);
                _player.LifeLost();
            }
        }
    }
}
