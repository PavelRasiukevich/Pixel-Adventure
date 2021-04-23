using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameInfo : BaseManager<GameInfo>
    {
        [SerializeField] List<LevelConfig> levelConfig;


        public List<LevelConfig> LevelConfig { get => levelConfig; }

        public int LifeAmount { get; set; }
        public int LevelIndex { get; set; }
        public bool IsGameOverScreenAtive { get; set; }

        public int Retry()
        {
            Time.timeScale = 1;
            LifeAmount = 3;
            return LevelIndex;
        }

        public LevelState GetLevelState(int _index)
        {
            return (LevelState)PlayerPrefs.GetInt(PrefsKeys.LEVEL_ + _index);
        }

        public void SetLevelState(int _index, LevelState _state)
        {
            PlayerPrefs.SetInt(PrefsKeys.LEVEL_ + _index, (int)_state);
        }
    }

    [Serializable]
    public class LevelConfig
    {
    }
}
