using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Slot : MonoBehaviour
    {
        public Action<Item> ItemEquiped { get; set; }

        [SerializeField] SlotContent slotContent;
        [SerializeField] bool isEmptySlot;
        [SerializeField] bool isEquipmentSlot;
        [SerializeField] int index;

        public SlotContent SlotContent { get => slotContent; set => slotContent = value; }
        public bool IsEmptySlot { get => isEmptySlot; set => isEmptySlot = value; }
        public int Index { get => index; set => index = value; }

        private void OnEnable()
        {
            if (IsEmptySlot == true)
                slotContent.HideSlotContent();
            else
                slotContent.ShowSlotContent();
        }

        public void InputItemInSlot(Item _item)
        {
            if (isEquipmentSlot)
            {
                ItemEquiped.Invoke(_item);
            }

                IsEmptySlot = false;
                SlotContent.ContentSprite = _item.Spr;
                SlotContent.Item = _item;
        }
    }
}
