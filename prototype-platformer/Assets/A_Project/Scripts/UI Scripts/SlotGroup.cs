using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SlotGroup : MonoBehaviour
    {
        public Action<Item> NotifyInventoryAboutEquip { get; set; }
        public Action<Item> NotifyInventoryAboutUnequip { get; set; }

        [SerializeField] List<Slot> listOfSlots;
        [SerializeField] SlotContent[] slotContentToSwap;
        [SerializeField] EquipmentSlotGroup equipmentGroup;

        Slot startSlot;
        Slot endSlot;

        private void Awake()
        {
            slotContentToSwap = new SlotContent[2];
        }

        private void OnEnable()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                listOfSlots[i].Equiped = EquipedHandler;
                listOfSlots[i].Unequiped = UnequipedHander;
                listOfSlots[i].SlotContent.ItemClicked = ItemClickedHandler;
                listOfSlots[i].SlotContent.ItemDroped = ItemDropedHandler;
            }

            for (int i = 0; i < equipmentGroup.transform.childCount; i++)
            {
                equipmentGroup.transform.GetChild(i).GetComponent<Slot>().SlotContent.ItemClicked = ItemClickedHandler;
                equipmentGroup.transform.GetChild(i).GetComponent<Slot>().SlotContent.ItemDroped = ItemDropedHandler;
                equipmentGroup.transform.GetChild(i).GetComponent<Slot>().Equiped = EquipedHandler;
            }
        }

        private void UnequipedHander(Item _item)
        {
            NotifyInventoryAboutUnequip.Invoke(_item);
        }

        private void EquipedHandler(Item _item)
        {
            NotifyInventoryAboutEquip.Invoke(_item);
        }

        private void ItemDropedHandler(SlotContent _slotContent)
        {
            slotContentToSwap[1] = _slotContent;
            endSlot = slotContentToSwap[1].ParentSlot;

            SlotSwitchHandler();
        }

        private void SlotSwitchHandler()
        {
            if (endSlot.IsEquipmentSlot == true)
            {
                if (startSlot.IsEmptySlot == false)
                {
                    if (endSlot.IsEmptySlot == true)
                    {
                        if (startSlot.IsEquipmentSlot == false)
                        {
                            SwapSlotContent();
                            endSlot.EquipItem(endSlot.SlotContent.Item);
                        }
                        else
                        {
                            SwapSlotContent();
                        }
                    }
                    else
                    {
                        if (startSlot.IsEquipmentSlot)
                        {
                            SwapSlotContent();
                        }
                        else
                        {
                            endSlot.UnEquipItem(endSlot.SlotContent.Item);
                            SwapSlotContent();
                            endSlot.EquipItem(endSlot.SlotContent.Item);
                        }
                    }
                }
            }
            else
            {
                if (startSlot.IsEmptySlot == false)
                {
                    if (endSlot.IsEmptySlot == true)
                    {
                        if (startSlot.IsEquipmentSlot == true)
                        {
                            startSlot.UnEquipItem(startSlot.SlotContent.Item);
                            SwapSlotContent();
                        }
                        else
                        {
                            SwapSlotContent();
                        }
                    }
                    else
                    {
                        if (startSlot.IsEquipmentSlot == true)
                        {
                            startSlot.UnEquipItem(startSlot.SlotContent.Item);
                            SwapSlotContent();
                            startSlot.EquipItem(startSlot.SlotContent.Item);
                        }
                        else
                        {
                            SwapSlotContent();
                        }
                    }
                }
            }
        }

        private void ItemClickedHandler(SlotContent _slotContent)
        {
            slotContentToSwap[0] = _slotContent;
            startSlot = slotContentToSwap[0].ParentSlot;
        }

        private void SwapSlotContent()
        {
            var _tempSprite = slotContentToSwap[0].SlotContentImage;
            slotContentToSwap[0].SlotContentImage = slotContentToSwap[1].SlotContentImage;
            slotContentToSwap[1].SlotContentImage = _tempSprite;

            var _tempItem = slotContentToSwap[0].Item;
            slotContentToSwap[0].Item = slotContentToSwap[1].Item;
            slotContentToSwap[1].Item = _tempItem;

            var _tempSpace = slotContentToSwap[0].ParentSlot.IsEmptySlot;
            slotContentToSwap[0].ParentSlot.IsEmptySlot = slotContentToSwap[1].ParentSlot.IsEmptySlot;
            slotContentToSwap[1].ParentSlot.IsEmptySlot = _tempSpace;

            for (int i = 0; i < slotContentToSwap.Length; i++)
            {
                slotContentToSwap[i].ParentSlot.RefreshslotDisplay();
            }
        }

        public void GetSlots()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                listOfSlots.Add(transform.GetChild(i).GetComponent<Slot>());
            }

            for (int i = 0; i < equipmentGroup.transform.childCount; i++)
            {
                listOfSlots.Add(equipmentGroup.transform.GetChild(i).GetComponent<Slot>());
            }
        }

        public void SetSlotOccupation()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                listOfSlots[i].IsEmptySlot = GameInfo.Instance.SlotValues[i];
                listOfSlots[i].SlotContent.SlotContentImage = GameInfo.Instance.ListOfSprites[i];
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
