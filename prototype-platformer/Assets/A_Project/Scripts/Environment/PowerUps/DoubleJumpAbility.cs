using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DoubleJumpAbility : BasePowerUp
    {
        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.HasDoubleJump = true;
            PickUpPowerUp();
        }
    }
}
