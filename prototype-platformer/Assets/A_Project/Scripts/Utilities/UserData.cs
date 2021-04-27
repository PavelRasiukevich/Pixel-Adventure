using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class UserData
    {
        [SerializeField] List<LevelState> listOfLevelStates;

        public List<LevelState> ListOfLevelStates { get => listOfLevelStates; }

        public UserData()
        {
            listOfLevelStates = new List<LevelState>();
        }
    }
}
