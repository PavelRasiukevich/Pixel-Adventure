using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{   
    public class JumpPowerUp : BasePowerUp
    {
        public override void AddBonusValue(IControllable _character)
        {
            GameInfo.Instance.CharData.JumpForce += value;
            PickUpPowerUp();
        }

    }
}
