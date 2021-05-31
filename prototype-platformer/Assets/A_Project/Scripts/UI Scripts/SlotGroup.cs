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
        [SerializeField] SlotContent[] arrayOfSlotContentToSwap;
        [SerializeField] EquipmentSlotGroup equipment;

        private void Awake()
        {
            arrayOfSlotContentToSwap = new SlotContent[2];
        }

        private void OnEnable()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                listOfSlots[i].Equiped = Equipedhandler;
                listOfSlots[i].SlotContent.ItemClicked = ItemClickedHandler;
                listOfSlots[i].SlotContent.ItemDroped = ItemDropedHandler;
            }

            for (int i = 0; i < equipment.transform.childCount; i++)
            {
                equipment.transform.GetChild(i).GetComponent<Slot>().SlotContent.ItemClicked = ItemClickedHandler;
                equipment.transform.GetChild(i).GetComponent<Slot>().SlotContent.ItemDroped = ItemDropedHandler;
                equipment.transform.GetChild(i).GetComponent<Slot>().Equiped = Equipedhandler;
            }
        }

        private void Equipedhandler(Item _item)
        {
            NotifyInventory.Invoke(_item);
        }

        private void ItemDropedHandler(SlotContent _slotContent)
        {
            arrayOfSlotContentToSwap[1] = _slotContent;
            SwapSlotContent();

        }

        private void ItemClickedHandler(SlotContent _slotContent)
        {
            arrayOfSlotContentToSwap[0] = _slotContent;
        }

        private void SwapSlotContent()
        {
            var _temp = arrayOfSlotContentToSwap[0].transform.parent;
            arrayOfSlotContentToSwap[0].transform.SetParent(arrayOfSlotContentToSwap[1].transform.parent);
            arrayOfSlotContentToSwap[1].transform.SetParent(_temp);

            arrayOfSlotContentToSwap[0].transform.localPosition = Vector3.zero;
            arrayOfSlotContentToSwap[1].transform.localPosition = Vector3.zero;


            var _slot1 = arrayOfSlotContentToSwap[0].GetParentSlot();
            var _slot2 = arrayOfSlotContentToSwap[1].GetParentSlot();


            _slot1.SlotContent = arrayOfSlotContentToSwap[0];
            _slot2.SlotContent = arrayOfSlotContentToSwap[1];

            _slot1.CheckForEquipment();
            _slot2.CheckForEquipment();

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
