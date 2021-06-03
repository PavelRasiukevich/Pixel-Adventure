using System;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class EnvironmentData
    {
        [SerializeField] bool isLvlArmRepaired;
        [SerializeField] bool isLvlArmOn;
        [SerializeField] bool isBridgeActivated;
        [SerializeField] int lvlArmAnimInteger;

        public bool IsLvlArmRepaired { get => isLvlArmRepaired; set => isLvlArmRepaired = value; }
        public bool IsLvlArmOn { get => isLvlArmOn; set => isLvlArmOn = value; }
        public bool IsBridgeActivated { get => isBridgeActivated; set => isBridgeActivated = value; }
        public int LvlArmAnimInteger { get => lvlArmAnimInteger; set => lvlArmAnimInteger = value; }
    }
}
