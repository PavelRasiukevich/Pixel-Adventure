using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SlotGroup : MonoBehaviour
    {
        public Action<Item> NotifyInventory { get; set; }

        [SerializeField] List<Slot> listOfSlots;

        private void OnEnable()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                listOfSlots[i].ItemEquiped = Handler;
            }
        }

        private void Handler(Item _item)
        {
            NotifyInventory.Invoke(_item);
        }

        public void GetSlots()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                listOfSlots.Add(transform.GetChild(i).GetComponent<Slot>());
            }
        }

        public void SetSlotOccupation()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                listOfSlots[i].IsEmptySlot = GameInfo.Instance.SlotValues[i];
                listOfSlots[i].SlotContent.ContentSprite = GameInfo.Instance.ListOfSprites[i];
                listOfSlots[i].Index = i;
            }
        }

        public Slot FindEmptySlot()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                if (listOfSlots[i].IsEmptySlot)
                    return listOfSlots[i];
            }

            return null;
        }
    }
}
