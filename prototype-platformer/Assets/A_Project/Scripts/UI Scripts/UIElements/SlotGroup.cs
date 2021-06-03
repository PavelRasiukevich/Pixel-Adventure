using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class SlotGroup : MonoBehaviour
    {
        public Action<ItemModel> NotifyInventoryAboutEquip { get; set; }
        public Action<ItemModel> NotifyInventoryAboutUnequip { get; set; }

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

        private void UnequipedHander(ItemModel _item)
        {
            NotifyInventoryAboutUnequip.Invoke(_item);
        }

        private void EquipedHandler(ItemModel _item)
        {
            NotifyInventoryAboutEquip.Invoke(_item);
        }

        private void ItemClickedHandler(SlotContent _slotContent)
        {
            slotContentToSwap[0] = _slotContent;
            startSlot = slotContentToSwap[0].ParentSlot;
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
                if (startSlot.SlotContent.ItemModel.isEquipableItem)
                {
                    if (startSlot.IsEmptySlot == false)
                    {
                        if (endSlot.IsEmptySlot == true)
                        {
                            if (startSlot.IsEquipmentSlot == false)
                            {
                                SwapSlotContent();
                                endSlot.EquipItem(endSlot.SlotContent.ItemModel);
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
                                endSlot.UnEquipItem(endSlot.SlotContent.ItemModel);
                                SwapSlotContent();
                                endSlot.EquipItem(endSlot.SlotContent.ItemModel);
                            }
                        }
                    }
                }
            }
            else
            {
                if (startSlot.IsEquipmentSlot && startSlot.IsEmptySlot == false)
                {
                    if (endSlot.IsEmptySlot)
                    {
                        startSlot.UnEquipItem(startSlot.SlotContent.ItemModel);
                        SwapSlotContent();
                    }
                    else
                    {
                        if (endSlot.SlotContent.ItemModel.isEquipableItem)
                        {
                            startSlot.UnEquipItem(startSlot.SlotContent.ItemModel);
                            SwapSlotContent();
                            startSlot.EquipItem(startSlot.SlotContent.ItemModel);
                        }
                    }
                }
                else if (!startSlot.IsEquipmentSlot && startSlot.IsEmptySlot == false)
                {
                    SwapSlotContent();
                }
            }
        }

        private void SwapSlotContent()
        {
            var _tempSprite = slotContentToSwap[0].SlotContentImage;
            slotContentToSwap[0].SlotContentImage = slotContentToSwap[1].SlotContentImage;
            slotContentToSwap[1].SlotContentImage = _tempSprite;

            var _tempItem = slotContentToSwap[0].ItemModel;
            slotContentToSwap[0].ItemModel = slotContentToSwap[1].ItemModel;
            slotContentToSwap[1].ItemModel = _tempItem;

            var _tempSpace = slotContentToSwap[0].ParentSlot.IsEmptySlot;
            slotContentToSwap[0].ParentSlot.IsEmptySlot = slotContentToSwap[1].ParentSlot.IsEmptySlot;
            slotContentToSwap[1].ParentSlot.IsEmptySlot = _tempSpace;

            for (int i = 0; i < slotContentToSwap.Length; i++)
            {
                slotContentToSwap[i].ParentSlot.RefreshslotDisplay();
            }

            GameInfo.Instance.SlotFullness[startSlot.Index] = startSlot.IsEmptySlot;
            GameInfo.Instance.ListOfSprites[startSlot.Index] = startSlot.SlotContent.SlotContentImage;
            GameInfo.Instance.ListOfItems[startSlot.Index] = startSlot.SlotContent.ItemModel;

            GameInfo.Instance.SlotFullness[endSlot.Index] = endSlot.IsEmptySlot;
            GameInfo.Instance.ListOfSprites[endSlot.Index] = endSlot.SlotContent.SlotContentImage;
            GameInfo.Instance.ListOfItems[endSlot.Index] = endSlot.SlotContent.ItemModel;
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
                listOfSlots[i].IsEmptySlot = GameInfo.Instance.SlotFullness[i];
                listOfSlots[i].SlotContent.SlotContentImage = GameInfo.Instance.ListOfSprites[i];
                listOfSlots[i].SlotContent.ItemModel = GameInfo.Instance.ListOfItems[i];
                listOfSlots[i].Index = i;
            }
        }

        public void FindItemByName(string _itemName)
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                if (listOfSlots[i].SlotContent.ItemModel.itemName == _itemName)
                {
                    GameInfo.Instance.ListOfItems[listOfSlots[i].Index] = listOfSlots[i].SlotContent.ItemModel = null;
                    GameInfo.Instance.ListOfSprites[listOfSlots[i].Index] = listOfSlots[i].SlotContent.SlotContentImage = null;
                    GameInfo.Instance.SlotFullness[listOfSlots[i].Index] = listOfSlots[i].IsEmptySlot = true;
                }
            }
        }

        public Slot FindEmptySlot()
        {
            for (int i = 0; i < listOfSlots.Count; i++)
            {
                if (listOfSlots[i].IsEmptySlot && !listOfSlots[i].IsEquipmentSlot)
                    return listOfSlots[i];
            }

            return null;
        }
    }
}
