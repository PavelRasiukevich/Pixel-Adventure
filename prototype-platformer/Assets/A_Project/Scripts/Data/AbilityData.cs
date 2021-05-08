using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class AbilityData
    {
        [SerializeField] List<PowerUpStates> listOfAbilitiesStates;

        public AbilityData()
        {
            listOfAbilitiesStates = new List<PowerUpStates>();
        }

        public List<PowerUpStates> ListOfStates { get => listOfAbilitiesStates; }
    }
}
