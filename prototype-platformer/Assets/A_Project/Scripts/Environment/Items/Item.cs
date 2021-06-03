using System;
using UnityEngine;

namespace PixelAdventure
{
    public class Item : MonoBehaviour
    {
        [Header("ITEM MODEL")] 
        [SerializeField]  ItemModel itemModel;

        [Header("ITEM")]
        [SerializeField] GameObject display;

        int index;
        ItemState itemState;

        private void OnEnable()
        {
            itemModel.itemSprite = GetComponent<SpriteRenderer>().sprite;
        }

        public ItemState ItemState { get => itemState; set => itemState = value; }
        public int Index { get => index; set => index = value; }

        public ItemModel ItemModel { get => itemModel; }

        public void Off()
        {
            gameObject.SetActive(false);
        }

        public void On()
        {
            gameObject.SetActive(true);
        }

        public void ShowDisplay(bool _value)
        {
            display.SetActive(_value);
        }

       
    }
}


