using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{   
    [Serializable]
    public class PowerUpData
    {
        [SerializeField] List<PowerUpStates> powerUps;

        public List<PowerUpStates> PowerUps { get => powerUps; }

        public PowerUpData()
        {
            powerUps = new List<PowerUpStates>();
        }
    }
}
