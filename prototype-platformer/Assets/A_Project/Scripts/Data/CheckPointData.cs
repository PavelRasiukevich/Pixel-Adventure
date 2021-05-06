using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class CheckPointData
    {
        [SerializeField] CharacterData charData;
        [SerializeField] UserData userData;
        [SerializeField] PowerUpData powerUpData;

        public CheckPointData(CharacterData _c, UserData _u, PowerUpData _p)
        {
            charData = _c;
            userData = _u;
            powerUpData = _p;
        }

        public CharacterData CharData { get => charData; }
        public UserData UserData { get => userData; }
        public PowerUpData PowerUpData { get => powerUpData;  }
    }
}
