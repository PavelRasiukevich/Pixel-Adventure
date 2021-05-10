using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FastFallAbility : BasePowerUp
    {
        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.HasFastFall = true;
            PickUpPowerUp();
        }
    }
}
