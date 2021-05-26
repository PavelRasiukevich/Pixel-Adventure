using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public class Item : MonoBehaviour
    {
        [SerializeField] Sprite spr;
        [SerializeField] string itemName;

        int index;
        ItemState itemState;

        public string ItemName { get => itemName; }
        public Sprite Spr { get => spr; }
        public ItemState ItemState { get => itemState; set => itemState = value; }
        public int Index { get => index; set => index = value; }

        public void Off()
        {
            gameObject.SetActive(false);
        }

        public void On()
        {
            gameObject.SetActive(true);
        }

        public Sprite GetSprite()
        {
            return Spr;
        }
    }
}
