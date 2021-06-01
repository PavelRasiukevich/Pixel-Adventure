using System;
using UnityEngine;

namespace PixelAdventure
{
    public class Inventory : MonoBehaviour
    {
        public Action<Item> NotifyPlayerAboutEquip { get; set; }
        public Action<Item> NotifyPlayerAboutUnequip { get; set; }

        [SerializeField] bool isOpened;

        [SerializeField] GameObject holder;
        [SerializeField] SlotGroup slotGroup;
        [SerializeField] EquipmentSlotGroup equipmentSlotGroup;

        public SlotGroup SlotGroup { get => slotGroup; }
        public EquipmentSlotGroup EquipmentSlotGroup { get => equipmentSlotGroup; }
        public GameObject Holder { get => holder; }

        private void Awake()
        {
            slotGroup.GetSlots();
            slotGroup.SetSlotOccupation();
            slotGroup.NotifyInventoryAboutEquip = EquipHandler;
            slotGroup.NotifyInventoryAboutUnequip = UnequipHanler;
        }

        private void UnequipHanler(Item _item)
        {
            NotifyPlayerAboutUnequip.Invoke(_item);
        }

        private void EquipHandler(Item _item)
        {
            NotifyPlayerAboutEquip.Invoke(_item);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!isOpened)
                    OpenInventory();
                else
                    CloseInventory();
            }
        }

        private void CloseInventory()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            holder.SetActive(false);
            isOpened = !isOpened;
        }

        private void OpenInventory()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            holder.SetActive(true);
            isOpened = !isOpened;
        }
    }
}
