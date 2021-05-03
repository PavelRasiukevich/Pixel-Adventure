using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class JumpPowerUp : BasePowerUp
    {
        public override void AddBonusValue(IControllable _character)
        {
            _character.CharStats.CurrentJumpForce += value;
            GameInfo.Instance.CharData.JumpForce = _character.CharStats.CurrentJumpForce;
            DestroyPowerUp();
        }
    }
}
