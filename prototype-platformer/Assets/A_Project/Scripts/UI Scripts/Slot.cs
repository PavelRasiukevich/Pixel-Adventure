using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] bool isEmpty;
        [SerializeField] Image itemImg;
        int index;

        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
        public int Index { get => index; set => index = value; }
        public Sprite SlotSprite { get => itemImg.sprite; set => itemImg.sprite = value; }

        private void OnEnable()
        {
            if (!IsEmpty)
                itemImg.gameObject.SetActive(!IsEmpty);
        }

        public void InputItemInSlot(Item _item)
        {
            itemImg.sprite = _item.Spr;
            IsEmpty = false;
            itemImg.gameObject.SetActive(true);
        }

        public void RemoveItemFromSlot()
        {
            itemImg.sprite = null;
            itemImg.gameObject.SetActive(false);
        }

        public int GetSlotIndex()
        {
            return Index;
        }
    }
}
