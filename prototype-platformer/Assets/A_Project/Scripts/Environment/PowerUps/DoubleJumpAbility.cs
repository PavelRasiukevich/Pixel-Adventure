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
            
        }

        public void DestroyPowerUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
