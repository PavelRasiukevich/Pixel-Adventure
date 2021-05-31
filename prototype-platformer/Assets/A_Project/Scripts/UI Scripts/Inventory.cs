using System;
using UnityEngine;

namespace PixelAdventure
{
    public class Inventory : MonoBehaviour
    {
        public Action<Item> NotifyPlayer { get; set; }

        [SerializeField] bool isOpened;
        [SerializeField] GameObject inv;
        [SerializeField] SlotGroup slotGroup;
        [SerializeField] EquipmentSlotGroup equipmentSlotGroup;

        public SlotGroup SlotGroup { get => slotGroup; set => slotGroup = value; }
        public EquipmentSlotGroup EquipmentSlotGroup { get => equipmentSlotGroup; set => equipmentSlotGroup = value; }

        private void Awake()
        {
            slotGroup.GetSlots();
            slotGroup.SetSlotOccupation();
            slotGroup.NotifyInventory = Handler;

        }

        private void Handler(Item _item)
        {
            NotifyPlayer.Invoke(_item);
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

            inv.SetActive(false);
            isOpened = !isOpened;
        }

        private void OpenInventory()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            inv.SetActive(true);
            isOpened = !isOpened;
        }
    }
}
