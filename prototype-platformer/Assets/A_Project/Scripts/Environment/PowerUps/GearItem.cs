using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GearItem : BasePower
    {
        private void Awake()
        {
            name = Values.GEAR_ITEM;
        }

        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.HasGear = true;
            gameObject.SetActive(false);
        }
    }
}
