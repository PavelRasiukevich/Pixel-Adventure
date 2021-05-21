using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SpeedPowerUp : BasePower
    {
        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.Speed += value;
            PickUpPowerUp();
        }

       
    }
}
