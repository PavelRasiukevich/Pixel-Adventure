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
        public bool HasReloadedDash { get; set; } = true;
        public bool HasReloadedDoubleJump { get; set; } = true;
        public bool HasReloadedFastFall { get; set; } = true;
        #endregion

        public void NewGameSetup()
        {
            //powerUpData
            powerData = new PowerUpData();

            for (int i = 0; i < 9; i++)
            {
                powerData.PowerUps.Add(PowerUpStates.Avaliable);
            }

            AppPrefs.SetObject(PrefsKeys.POWERUPS_DATA, powerData);

            //charData
            charData = new CharacterData
            {
                Speed = CharStatsSO.InitialSpeed,
                JumpForce = CharStatsSO.InitialJumpForce,
                DashLenght = CharStatsSO.InitialDashLenght,
                HasDash = CharStatsSO.HasDashAbility,
                HasDoubleJump = CharStatsSO.HasDoubleJumpAbility,
                HasFastFall = CharStatsSO.HasFastFallAbility,
                DashReloadTime = CharStatsSO.DashReloadTime,
                DoubleJumpReloadTime = CharStatsSO.DoubleJumpReloadTime,
                FastFallReloadTime = CharStatsSO.FastFallReloadTime
            };

            AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);

            //userData
            userData = new UserData();
            userData.PlayerSpawnPosition = Spawn;

            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);
        }

        public void LoadGameProgress()
        {
            userData = AppPrefs.GetObject<UserData>(PrefsKeys.USER_DATA);
            charData = AppPrefs.GetObject<CharacterData>(PrefsKeys.CHARACTER_DATA);
            powerData = AppPrefs.GetObject<PowerUpData>(PrefsKeys.POWERUPS_DATA);

            if (userData == null || charData == null || powerData == null)
                NewGameSetup();
        }

        public void SaveGameProgress()
        {
            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);
            AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);
            AppPrefs.SetObject(PrefsKeys.POWERUPS_DATA, powerData);
        }

        public void Retry()
        {
            Time.timeScale = 1;
            LifeAmount = 3;
            LoadGameProgress();
        }

        public void SetScore(int _score)
        {
            userData.Score += _score;
        }

        public int GetScore()
        {
            return userData.Score;
        }

        public PowerUpStates GetPowerUpState(int _index)
        {
            return powerData.PowerUps[_index];
        }

        public void SetPowerUpState(int _index, PowerUpStates _state)
        {
            powerData.PowerUps[_index] = _state;
        }
    }
}
