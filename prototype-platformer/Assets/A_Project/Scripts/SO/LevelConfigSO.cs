using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfigSO : ScriptableObject
    {
        [SerializeField] List<LevelConfig> levelConfig;

        public List<LevelConfig> LevelConfig => levelConfig;
    }

    [Serializable]
    public class LevelConfig
    {
        [SerializeField] string name;
        [SerializeField] int index;

        public int Index { get => index; }
        public string Name { get => name; }
    }
}
