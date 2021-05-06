using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class UserData
    {
        [SerializeField] Vector3 playerSpawnPosition;

        public Vector3 PlayerSpawnPosition { get => playerSpawnPosition; set => playerSpawnPosition = value; }

    }
}
