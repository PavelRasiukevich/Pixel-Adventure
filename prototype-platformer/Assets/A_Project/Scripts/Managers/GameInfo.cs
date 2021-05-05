using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameInfo : BaseManager<GameInfo>
    {
        [SerializeField] CheckPointConfig_SO checkPointConfig_SO;
        [SerializeField] CharacterStatsSO charStatsSO;

        UserData userData;
        CharacterData charData;
        PowerUpData powerData;

        #region Properties
        public int LifeAmount { get; set; }
        public string LevelName { get; set; }
        public bool IsGameOverScreenActive { get; set; }
        public UserData UserData { get => userData; }

        public List<PowerUpStates> PowerUps => powerData.PowerUps;
        public List<CheckPointConfig> CheckPointConfigs => checkPointConfig_SO.CheckPointConfig;
        public Vector3 Spawn => checkPointConfig_SO.Spawn;
        public CharacterStatsSO CharStatsSO { get => charStatsSO; }
        public CharacterData CharData { get => charData; }
        #endregion

        public void Setup()
        {

            if (AppPrefs.HasObject(PrefsKeys.POWERUPS_DATA))
            {
                powerData = AppPrefs.GetObject<PowerUpData>(PrefsKeys.POWERUPS_DATA);

            }
            else
            {
                powerData = new PowerUpData();

                for (int i = 0; i < 3; i++)
                {
                    powerData.PowerUps.Add(PowerUpStates.Avaliable);
                }

                AppPrefs.SetObject(PrefsKeys.POWERUPS_DATA, powerData);
            }

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
                    DashLenght = CharStatsSO.InitialDashLenght,
                    HasDash = CharStatsSO.HasDashAbility,
                    HasDoubleJump = CharStatsSO.HasDoubleJumpAbility

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

        public void LoadProgress()
        {
            userData = AppPrefs.GetObject<UserData>(PrefsKeys.USER_DATA);
            charData = AppPrefs.GetObject<CharacterData>(PrefsKeys.CHARACTER_DATA);
            powerData = AppPrefs.GetObject<PowerUpData>(PrefsKeys.POWERUPS_DATA);
        }

        public void SaveProgress()
        {

            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);
            AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);
            AppPrefs.SetObject(PrefsKeys.POWERUPS_DATA, powerData);
            AppPrefs.Save();

        }

        public void Retry()
        {
            Time.timeScale = 1;
            LifeAmount = 3;
            SaveProgress();
            Setup();
        }

        public PowerUpStates GetPowerUpState(int _index)
        {
            return powerData.PowerUps[_index];
        }

        public void SetPowerUpState(int _index, PowerUpStates _state)
        {
            powerData.PowerUps[_index] = _state;
        }

        public CheckPointState GetCheckPointState(int _index)
        {
            return userData.ListOfCheckPointState[_index];
        }

        public void SetCheckPointState(int _index, CheckPointState _state)
        {
            userData.ListOfCheckPointState[_index] = _state;
        }

        public void SetInitialValues()
        {

            for (int i = 0; i < CheckPointConfigs.Count; i++)
            {
                userData.ListOfCheckPointState.Add(CheckPointState.Locked);
            }

            userData.PlayerSpawnPosition = Spawn;

            userData.MasterVolume = 0;
            userData.MusicVolume = 0;
            userData.SoundVolume = 0;
        }
    }


}
