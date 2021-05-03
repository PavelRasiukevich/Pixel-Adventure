using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameInfo : BaseManager<GameInfo>
    {
        [SerializeField] LevelConfigSO levelConfigSO;
        [SerializeField] CharacterStatsSO charStatsSO;

        UserData userData;
        CharacterData charData;

        #region Properties
        public int LifeAmount { get; set; }
        public string LevelName { get; set; }
        public bool IsGameOverScreenActive { get; set; }
        public UserData UserData { get => userData; }
        public List<LevelConfig> LevelConfig => levelConfigSO.LevelConfig;
        public CharacterStatsSO CharStatsSO { get => charStatsSO; }
        public CharacterData CharData { get => charData; }
        #endregion

        public void Setup()
        {

            if (AppPrefs.HasObject(PrefsKeys.CHARACTER_DATA))
            {
                charData = AppPrefs.GetObject<CharacterData>(PrefsKeys.CHARACTER_DATA);
            }
            else
            {
                charData = new CharacterData
                {
                    Speed = CharStatsSO.InitialSpeed,
                    JumpForce = CharStatsSO.InitialJumpForce,
                    DoubleJumpForce = CharStatsSO.InitialDoubleJumpForce,
                    FastFallSpeed = CharStatsSO.InitialFastFallSpeed,
                    DashLenght = CharStatsSO.InitialDashLenght
                };

                AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);
            }

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
            userData.ListOfLevelStates[_index + 1] = LevelState.Unlocked;

            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);
            AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);
            AppPrefs.Save();

        }

        public string Retry()
        {
            AppPrefs.DeleteObject(PrefsKeys.CHARACTER_DATA);
            Setup();
            Time.timeScale = 1;
            LifeAmount = 3;
            return LevelName;
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

            for (int i = 0; i < levelConfigSO.LevelConfig.Count; i++)
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


}
