using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Slot : MonoBehaviour
    {
        public Action<Item> Equiped { get; set; }

        [SerializeField] SlotContent slotContent;
        [SerializeField] bool isEmptySlot;
        [SerializeField] bool isEquipmentSlot;
        [SerializeField] int index;

        public SlotContent SlotContent { get => slotContent; set => slotContent = value; }
        public bool IsEmptySlot { get => isEmptySlot; set => isEmptySlot = value; }
        public int Index { get => index; set => index = value; }
        public bool IsEquipmentSlot { get => isEquipmentSlot; }

        private void OnEnable()
        {
            if (IsEmptySlot == true)
                slotContent.HideSlotContent();
            else
                slotContent.ShowSlotContent();
        }

        public void InputItemInSlot(Item _item)
        {
            IsEmptySlot = false;
            SlotContent.ContentSprite = _item.Spr;
            SlotContent.Item = _item;
            Debug.Log(slotContent.Item.ItemName);
        }

        public void CheckForEquipment()
        {
            if (isEquipmentSlot)
            {
                Debug.Log(gameObject.name);
                Debug.Log(SlotContent.name);

                var _item = SlotContent.Item;

                if (IsEmptySlot == false)
                {
                    if (_item)
                        EquipItem(_item);
                }
            }
        }

        public void EquipItem(Item _item)
        {
            Equiped.Invoke(_item);
        }

        public void UnEquipItem()
        {

        }
    }
}
