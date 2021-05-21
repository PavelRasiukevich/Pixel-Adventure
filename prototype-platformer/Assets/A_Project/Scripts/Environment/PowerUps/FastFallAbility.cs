using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class FastFallAbility : BasePower
    {

        private void Awake()
        {
            name = Values.FAST_FALL;
        }

        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.HasFastFall = true;
            PickUpPowerUp();
        }
    }
}
