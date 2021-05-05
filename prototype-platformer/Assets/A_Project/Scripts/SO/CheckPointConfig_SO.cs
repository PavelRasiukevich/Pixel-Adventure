using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [CreateAssetMenu(fileName = "CheckPointConfig", menuName = "Configs/CheckPointConfig")]
    public class CheckPointConfig_SO : ScriptableObject
    {
        [SerializeField] List<CheckPointConfig> checkPointConfig;
        [SerializeField] Vector3 spawn;

        public List<CheckPointConfig> CheckPointConfig => checkPointConfig;

        public Vector3 Spawn { get => spawn;}
    }

    [Serializable]
    public class CheckPointConfig
    {
        [SerializeField] int index;

        public int Index { get => index; }
    }
}
