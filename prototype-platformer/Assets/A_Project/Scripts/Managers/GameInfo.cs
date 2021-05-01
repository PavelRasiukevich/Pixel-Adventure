using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameInfo : BaseManager<GameInfo>
    {
        [SerializeField] List<LevelConfig> levelConfig;

        UserData userData;

        #region Properties
        public List<LevelConfig> LevelConfig { get => levelConfig; }
        public int LifeAmount { get; set; }
        public int LevelIndex { get; set; }
        public bool IsGameOverScreenActive { get; set; }
        public UserData UserData { get => userData; }
        #endregion

        public void Setup()
        {

            if (AppPrefs.HasObject(PrefsKeys.USER_DATA))
            {
                userData = AppPrefs.GetObject<UserData>(PrefsKeys.USER_DATA);
            }
            else
            {
                userData = new UserData();

                SetInitialValues();

                AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);
            }
        }

        public void LevelComplited(int _index)
        {
            userData.ListOfLevelStates[_index] = LevelState.Unlocked;

            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);

            AppPrefs.Save();

        }

        public int Retry()
        {
            Time.timeScale = 1;
            LifeAmount = 3;
            return LevelIndex;
        }

        public LevelState GetLevelState(int _index)
        {
            return userData.ListOfLevelStates[_index];
        }

        public void SetLevelState(int _index, LevelState _state)
        {
            userData.ListOfLevelStates[_index] = _state;
        }

        public void SetInitialValues()
        {

            for (int i = 0; i < levelConfig.Count; i++)
            {
                if (i == 0)
                    userData.ListOfLevelStates.Add(LevelState.Unlocked);
                else
                    userData.ListOfLevelStates.Add(LevelState.Locked);
            }

            userData.MasterVolume = 0;
            userData.MusicVolume = 0;
            userData.SoundVolume = 0;
        }
    }

    [Serializable]
    public class LevelConfig
    {
        [SerializeField] int index;
    }
}
