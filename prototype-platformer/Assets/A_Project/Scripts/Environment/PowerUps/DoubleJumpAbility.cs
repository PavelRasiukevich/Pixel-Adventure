using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DoubleJumpAbility : BasePower
    {
        private void Awake()
        {
            name = Values.DOUBLE_JUMP;
        }

        public override void AddBonusValue()
        {
            GameInfo.Instance.CharData.HasDoubleJump = true;
            PickUpPowerUp();
        }
    }
}
