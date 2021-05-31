using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class SlotContent : MonoBehaviour
    {
        public Action<SlotContent> ItemClicked { get; set; } 
        public Action<SlotContent> ItemDroped { get; set; } 

        [SerializeField] Image itemImg;
        [SerializeField] Item item;

        public Sprite ContentSprite { get => itemImg.sprite; set => itemImg.sprite = value; }
        public Item Item { get => item; set => item = value; }

        public void ShowSlotContent()
        {
            var _color = itemImg.color;
            _color.a = 255;
            itemImg.color = _color;
        }

        public void HideSlotContent()
        {
            var _color = itemImg.color;
            _color.a = 0;
            itemImg.color = _color;
        }

        public void OnPointerDown(BaseEventData _eventData)
        {
            ItemClicked.Invoke(this);
        }


        public void OnPointerUp(BaseEventData _eventData)
        {
            ItemDroped.Invoke(this);
        }

        public Slot GetParentSlot()
        {
           return transform.parent.GetComponent<Slot>();
        }
    }
}
