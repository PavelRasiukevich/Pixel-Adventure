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
        AbilityUIData abilityUIData;

        #region Properties
        public string LevelName { get; set; }
        public bool IsGameOverScreenActive { get; set; }

        public UserData UserData { get => userData; }
        public CharacterData CharData { get => charData; }

        public List<PowerUpStates> PowerUps => powerData.PowerUps;
        public Vector3 Spawn => checkPointConfig_SO.Spawn;
        public CharacterStatsSO CharStatsSO { get => charStatsSO; }

        public AbilityUIData AbilityUIData { get => abilityUIData; }
        #endregion

        public void NewGameSetup()
        {
            powerData = null;

            //iconUIData
            abilityUIData = new AbilityUIData();

            AppPrefs.SetObject(PrefsKeys.ABILITY_UI_DATA, AbilityUIData);

            //charData
            charData = new CharacterData
            {
                LiveAmount = CharStatsSO.LiveAmount,
                Speed = CharStatsSO.InitialSpeed,
                JumpForce = CharStatsSO.InitialJumpForce,
                DashForce = CharStatsSO.InitialDashForce,
                HasDash = CharStatsSO.HasDashAbility,
                HasDoubleJump = CharStatsSO.HasDoubleJumpAbility,
                HasFastFall = CharStatsSO.HasFastFallAbility,
                DashReloadTime = CharStatsSO.DashReloadTime,
                DoubleJumpReloadTime = CharStatsSO.DoubleJumpReloadTime,
                FastFallReloadTime = CharStatsSO.FastFallReloadTime,
                DashDuration = CharStatsSO.DashDuration,
                HasGear = CharStatsSO.HasGear,
                HasReloadedDash = true,
                HasReloadedDoubleJump = true,
                HasReloadedFastFall = true

            };

            AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);

            //userData
            userData = new UserData();

            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);

        }

        public void InitPowerupData(int _powerUpCount)
        {
            if (powerData == null)
            {
                powerData = new PowerUpData();

                for (int i = 0; i < _powerUpCount; i++)
                {
                    powerData.PowerUps.Add(PowerUpStates.Avaliable);
                }

                AppPrefs.SetObject(PrefsKeys.POWERUPS_DATA, powerData);
            }

        }

        public void LoadGameProgress()
        {

            userData = AppPrefs.GetObject<UserData>(PrefsKeys.USER_DATA);
            charData = AppPrefs.GetObject<CharacterData>(PrefsKeys.CHARACTER_DATA);
            powerData = AppPrefs.GetObject<PowerUpData>(PrefsKeys.POWERUPS_DATA);
            abilityUIData = AppPrefs.GetObject<AbilityUIData>(PrefsKeys.ABILITY_UI_DATA);

            if (userData == null || charData == null || powerData == null)
            {
                NewGameSetup();
            }

            charData.ReserCoolDown();
        }

        public void SaveGameProgress()
        {
            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);
            AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);
            AppPrefs.SetObject(PrefsKeys.POWERUPS_DATA, powerData);
            AppPrefs.SetObject(PrefsKeys.ABILITY_UI_DATA, abilityUIData);
        }

        public void Retry()
        {
            Time.timeScale = 1;
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

        public void SetSavePointId(int _id)
        {
            userData.Id = _id;
        }

        public Vector2 GetPositionBySavePointId()
        {
            var _saves = FindObjectsOfType<SavePoint>();

            foreach (var point in _saves)
            {
                if (point.Id.Equals(userData.Id))
                {
                    return point.GetPosition();
                }
            }

            return Spawn;
        }
    }
}
