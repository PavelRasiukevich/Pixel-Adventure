using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Points : BasePowerUp
    {
        public override void AddBonusValue()
        {
            PickUpPowerUp();
        }
    }
}
