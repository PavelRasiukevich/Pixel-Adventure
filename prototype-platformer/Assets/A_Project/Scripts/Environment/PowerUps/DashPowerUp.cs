using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DashPowerUp : BasePowerUp
    {
        public override void AddBonusValue(IControllable _character)
        {
            
            _character.CharStats.CurrentDashLenght += value;
            GameInfo.Instance.CharData.DashLenght = _character.CharStats.CurrentDashLenght;
            DestroyPowerUp();
        }
    }
}
