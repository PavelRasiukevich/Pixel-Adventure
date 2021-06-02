using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class GameInfo : BaseManager<GameInfo>
    {
        [SerializeField] CharacterStatsSO charStatsSO;

        bool isPlaying;
        bool hasTransited;

        UserData userData;
        CharacterData charData;
        PowerUpData powerData;
        AbilityUIData abilityUIData;
        ItemData itemData;
        SlotData slotData;
        AbilitySlotData abilitySlotData;

        public bool isInGodMod;

        #region Properties
        public string LevelName { get; set; }
        public bool IsGameOverScreenActive { get; set; }

        public UserData UserData { get => userData; }
        public CharacterData CharData { get => charData; }

        public List<PowerUpStates> PowerUps => powerData.PowerUps;
        public List<ItemState> ItemStates => itemData.ListOfItemStates;

        public List<bool> SlotFullness => slotData.ListOfFullness;
        public List<Sprite> ListOfSprites => slotData.ListOfSprites;
        public List<ItemModel> ListOfItems => slotData.ListOfItems;


        public CharacterStatsSO CharStatsSO { get => charStatsSO; }

        public AbilityUIData AbilityUIData { get => abilityUIData; }
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }
        public bool HasTransited { get => hasTransited; set => hasTransited = value; }
        public AbilitySlotData AbilitySlotData { get => abilitySlotData; }
        #endregion

        public void NewGameSetup()
        {
            powerData = null;
            itemData = null;

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
            KeepCameraBounds(userData.KeepedValues.InitializeDefault());
            userData.SetBoundsValues();

            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);

            //inventory slots
            slotData = new SlotData();
            slotData.InitSlotValues();

            AppPrefs.SetObject(PrefsKeys.SLOT_DATA, slotData);


            abilitySlotData = new AbilitySlotData();
            abilitySlotData.InitSlotValues();

            AppPrefs.SetObject(PrefsKeys.ABILITY_SLOT_DATA, abilitySlotData);

            isPlaying = true;
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

        public void InitItemData(int _itemsCount)
        {
            if (itemData == null)
            {
                itemData = new ItemData();

                for (int i = 0; i < _itemsCount; i++)
                {
                    itemData.ListOfItemStates.Add(ItemState.Avaliable);
                }
                AppPrefs.SetObject(PrefsKeys.ITEM_DATA, itemData);
            }
        }

        public void LoadGameProgress()
        {

            userData = AppPrefs.GetObject<UserData>(PrefsKeys.USER_DATA);
            charData = AppPrefs.GetObject<CharacterData>(PrefsKeys.CHARACTER_DATA);
            powerData = AppPrefs.GetObject<PowerUpData>(PrefsKeys.POWERUPS_DATA);
            itemData = AppPrefs.GetObject<ItemData>(PrefsKeys.ITEM_DATA);
            abilityUIData = AppPrefs.GetObject<AbilityUIData>(PrefsKeys.ABILITY_UI_DATA);
            slotData = AppPrefs.GetObject<SlotData>(PrefsKeys.SLOT_DATA);
            abilitySlotData = AppPrefs.GetObject<AbilitySlotData>(PrefsKeys.ABILITY_SLOT_DATA);

            if (userData == null || charData == null || powerData == null)
            {
                NewGameSetup();
            }

            charData.ResetCooldown();
        }

        public void SaveGameProgress()
        {
            AppPrefs.SetObject(PrefsKeys.USER_DATA, userData);
            AppPrefs.SetObject(PrefsKeys.CHARACTER_DATA, charData);
            AppPrefs.SetObject(PrefsKeys.POWERUPS_DATA, powerData);
            AppPrefs.SetObject(PrefsKeys.ITEM_DATA, itemData);
            AppPrefs.SetObject(PrefsKeys.ABILITY_UI_DATA, abilityUIData);
            AppPrefs.SetObject(PrefsKeys.SLOT_DATA, slotData);
            AppPrefs.SetObject(PrefsKeys.ABILITY_SLOT_DATA, abilitySlotData);
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

        public ItemState GetItemState(int _index)
        {
            return itemData.ListOfItemStates[_index];
        }

        public void SetItemState(int _index, ItemState _state)
        {
            itemData.ListOfItemStates[_index] = _state;
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
            var _saves = FindObjectsOfType<SaveSpot>();

            foreach (var point in _saves)
            {
                if (point.Id.Equals(userData.Id))
                {
                    return point.GetPosition();
                }
            }

            return Vector2.zero;
        }

        public bool HasLoad()
        {
            if (AppPrefs.HasObject(PrefsKeys.USER_DATA))
                return AppPrefs.GetObject<UserData>(PrefsKeys.USER_DATA).IsLoadAvaliable;

            return false;
        }

        public void KeepCameraBounds(CameraBoundValues _values)
        {
            userData.KeepedValues = _values;
        }

        public CameraBoundValues GetCameraBounds()
        {
            return userData.CameraBoundValues;
        }

        public void InspectQuestItemInInventory(string _itemName)
        {
            switch (_itemName)
            {
                case Values.GEAR:
                    charData.HasGear = true;
                    break;
            }
        }
    }
}
