using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SpeedPowerUp : BasePowerUp
    {
        public override void AddBonusValue(IControllable _character)
        {
            GameInfo.Instance.CharData.Speed += value;
        }

       
    }
}
