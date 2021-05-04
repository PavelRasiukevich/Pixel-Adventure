using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public interface IPowerUp 
    {
        public int RewardPoints { get; }

        public void AddBonusValue(IControllable _character);
        public void DestroyPowerUp();
    }
}
