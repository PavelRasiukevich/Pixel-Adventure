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

        [SerializeField] float masterVolume;
        [SerializeField] float musicVolume;
        [SerializeField] float soundVolume;

        public List<LevelState> ListOfLevelStates { get => listOfLevelStates; }

        public float MasterVolume { get => masterVolume; set => masterVolume = value; }
        public float MusicVolume { get => musicVolume; set => musicVolume = value; }
        public float SoundVolume { get => soundVolume; set => soundVolume = value; }

        public UserData()
        {
            listOfLevelStates = new List<LevelState>();
        }
    }
}
