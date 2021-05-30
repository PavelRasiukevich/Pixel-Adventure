using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Item : MonoBehaviour
    {
        [SerializeField] string itemName;
        [SerializeField] bool canBePicked;
        [SerializeField] GameObject display;

        int index;
        ItemState itemState;

        SpriteRenderer sprR;

        private void Awake()
        {
            sprR = GetComponent<SpriteRenderer>();
        }

        public string ItemName { get => itemName; }
        public Sprite Spr { get => sprR.sprite; }
        public ItemState ItemState { get => itemState; set => itemState = value; }
        public int Index { get => index; set => index = value; }
        public bool CanBePicked { get => canBePicked; set => canBePicked = value; }

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


