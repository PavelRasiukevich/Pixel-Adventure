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

        [SerializeField] Image slotContentImage;
        [SerializeField] Item item;


        public Item Item { get => item; set => item = value; }
        public Sprite SlotContentImage { get => slotContentImage.sprite; set => slotContentImage.sprite = value; }
        public Slot ParentSlot { get => GetComponentInParent<Slot>(); }



        public void ShowSlotContent()
        {
            var _color = slotContentImage.color;
            _color.a = 255;
            slotContentImage.color = _color;
        }

        public void HideSlotContent()
        {
            var _color = slotContentImage.color;
            _color.a = 0;
            slotContentImage.color = _color;
        }

        public void OnPointerDown(BaseEventData _eventData)
        {
            ItemClicked.Invoke(this);
        }

        public void OnPointerUp(BaseEventData _eventData)
        {
            ItemDroped.Invoke(this);
        }
    }
}
