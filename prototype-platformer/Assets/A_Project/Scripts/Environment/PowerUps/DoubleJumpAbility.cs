using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DoubleJumpAbility : MonoBehaviour, IAbility
    {
       
        public void AddAbility(IControllable _player)
        {
            GameInfo.Instance.CharData.HasDoubleJump = true;
            DestroyPowerUp();
        }

        public void DestroyPowerUp()
        {
            Destroy(gameObject);
        }
    }
}
