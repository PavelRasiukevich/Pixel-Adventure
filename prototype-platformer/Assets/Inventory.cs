using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] bool isOpened;
        [SerializeField] GameObject inv;
        [SerializeField] SlotGroup slotGroup;

        public SlotGroup SlotGroup { get => slotGroup; set => slotGroup = value; }

        private void Awake()
        {
            slotGroup.GetSlots();
            slotGroup.SetSlotOccupation();
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
            inv.SetActive(false);
            isOpened = !isOpened;
        }

        private void OpenInventory()
        {
            inv.SetActive(true);
            isOpened = !isOpened;
        }
    }
}
