using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{   
    public interface IPowerUp 
    {
        public string GetName { get; }
        public int RewardPoints { get; }

        public void AddBonusValue();
        public void PickUpPowerUp();
    }
}
