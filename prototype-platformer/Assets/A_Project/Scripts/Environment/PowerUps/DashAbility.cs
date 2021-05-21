using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DashAbility : BasePower
    {
        private void Awake()
        {
            name = Values.DASH;
        }

        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.HasDash = true;
            PickUpPowerUp();
        }
    }
}
