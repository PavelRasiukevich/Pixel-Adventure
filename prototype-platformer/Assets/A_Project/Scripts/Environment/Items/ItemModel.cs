using System;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class ItemModel
    {
        [Header("Item Data")]
        [SerializeField] public bool isEquipableItem;
        [SerializeField] public bool isQuestItem;
        [SerializeField] public string itemName;
        [SerializeField] public bool canBePicked;
        [SerializeField] public Sprite itemSprite;

        [Header("Provided Ability Data")]
        [SerializeField] public Sprite itemAbilitySprite;
        [SerializeField] public string itemAbilityName;

        public void Apply(string _abilityName)
        {
            switch (_abilityName)
            {
                case Values.DASH:
                    GameInfo.Instance.CharData.HasDash = true;
                    break;
                case Values.FASTFALL:
                    GameInfo.Instance.CharData.HasFastFall = true;
                    break;
                case Values.DOUBLEJUMP:
                    GameInfo.Instance.CharData.HasDoubleJump = true;
                    break;
            }
        }

        public void Lose(string _abilityName)
        {
            switch (_abilityName)
            {
                case Values.DASH:
                    GameInfo.Instance.CharData.HasDash = false;
                    break;
                case Values.FASTFALL:
                    GameInfo.Instance.CharData.HasFastFall = false;
                    break;
                case Values.DOUBLEJUMP:
                    GameInfo.Instance.CharData.HasDoubleJump = false;
                    break;
            }
        }
    }
}
