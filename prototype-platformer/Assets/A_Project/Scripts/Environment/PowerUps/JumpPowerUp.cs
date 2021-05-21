using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{   
    public class JumpPowerUp : BasePower
    {
        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.JumpForce += value;
            PickUpPowerUp();
        }

    }
}
