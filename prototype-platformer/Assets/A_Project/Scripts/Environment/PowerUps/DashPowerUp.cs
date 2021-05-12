using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class DashPowerUp : BasePowerUp
    {
        public override void AddBonusValue()
        {

            var _dashLenght= GameInfo.Instance.CharData.DashLenght;
            _dashLenght.x += value;
            GameInfo.Instance.CharData.DashLenght = _dashLenght;
            PickUpPowerUp();
        }

       
    }
}
