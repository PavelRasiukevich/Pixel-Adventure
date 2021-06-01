using System;
using UnityEngine;

namespace PixelAdventure
{
    public class Slot : MonoBehaviour
    {
        public Action<ItemModel> Equiped { get; set; }
        public Action<ItemModel> Unequiped { get; set; }

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
            RefreshslotDisplay();
        }

        public void RefreshslotDisplay()
        {
            if (IsEmptySlot == true)
                slotContent.HideSlotContent();
            else
                slotContent.ShowSlotContent();
        }

        public void InputItemInSlot(Item _item)
        {
            IsEmptySlot = false;
            SlotContent.SlotContentImage = _item.ItemModel.itemSprite;
            SlotContent.Item = _item.ItemModel;

            //save to appprefs
        }

        public void EquipItem(ItemModel _item)
        {
            Equiped.Invoke(_item);
        }

        public void UnEquipItem(ItemModel item)
        {
            Unequiped.Invoke(item);
        }
    }
}
