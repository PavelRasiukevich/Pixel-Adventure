using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Points : BasePower
    {
        public override void AddBonusValue()
        {
            PickUpPowerUp();
        }
    }
}
