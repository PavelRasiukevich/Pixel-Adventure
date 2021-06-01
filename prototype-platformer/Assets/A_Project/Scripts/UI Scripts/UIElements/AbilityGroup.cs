using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class AbilityGroup : MonoBehaviour
    {
        [SerializeField] List<AbilitySlot> abilityList;


        private void Awake()
        {
            GetAllAbilitySlots();
            InitializeAbilitySlots();
        }

        private void InitializeAbilitySlots()
        {
            for (int i = 0; i < abilityList.Count; i++)
            {
                abilityList[i].IsEmpty = GameInfo.Instance.AbilitySlotData.ListOfValues[i];
                abilityList[i].FillImg.sprite = GameInfo.Instance.AbilitySlotData.ListOfSprites[i];
                abilityList[i].BackImg.sprite = GameInfo.Instance.AbilitySlotData.ListOfSprites[i];
                abilityList[i].Name = GameInfo.Instance.AbilitySlotData.ListOfNames[i];
                abilityList[i].Index = i;
            }
        }

        private void GetAllAbilitySlots()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                abilityList.Add(transform.GetChild(i).GetComponent<AbilitySlot>());
            }
        }

        public AbilitySlot FindEmptyAbilitySlot()
        {
            for (int i = 0; i < abilityList.Count; i++)
            {
                if (abilityList[i].IsEmpty)
                    return abilityList[i];
            }

            return null;
        }

        public AbilitySlot GetAbilitySlotByName(string _name)
        {
            foreach (var ability in abilityList)
            {
                if (ability.Name.Equals(_name))
                    return ability;
            }

            return null;
        }
    }
}
