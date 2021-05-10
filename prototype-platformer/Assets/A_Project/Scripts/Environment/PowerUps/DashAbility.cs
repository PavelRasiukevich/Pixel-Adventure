using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DashAbility : BasePowerUp
    {
        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.HasDash = true;
            PickUpPowerUp();
        }
    }
}
