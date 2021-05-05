using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class UserData
    {
        [SerializeField] List<CheckPointState> listOfCheckPointStates;

        [SerializeField] float masterVolume;
        [SerializeField] float musicVolume;
        [SerializeField] float soundVolume;
        [SerializeField] Vector3 playerSpawnPosition;

        public List<CheckPointState> ListOfCheckPointState { get => listOfCheckPointStates; }

        public float MasterVolume { get => masterVolume; set => masterVolume = value; }
        public float MusicVolume { get => musicVolume; set => musicVolume = value; }
        public float SoundVolume { get => soundVolume; set => soundVolume = value; }
        public Vector3 PlayerSpawnPosition { get => playerSpawnPosition; set => playerSpawnPosition = value; }

        public UserData()
        {
            listOfCheckPointStates = new List<CheckPointState>();
        }
    }
}
