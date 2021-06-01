using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class Item : MonoBehaviour, IEquipable
    {
        [Header("Item Data")]
        [SerializeField] string itemName;
        [SerializeField] bool canBePicked;
        [SerializeField] GameObject display;
        [SerializeField] Sprite itemSprite;

        [Header("Provided Ability Data")]
        [SerializeField] Sprite itemAbilitySprite;
        [SerializeField] string itemAbilityName;

        int index;
        ItemState itemState;

        [SerializeField] SpriteRenderer sprR;

        private void OnEnable()
        {
            itemSprite = GetComponent<SpriteRenderer>().sprite;
        }

        public Sprite ItemSprite { get => itemSprite; }
        public string ItemName { get => itemName; }
        public ItemState ItemState { get => itemState; set => itemState = value; }
        public int Index { get => index; set => index = value; }
        public bool CanBePicked { get => canBePicked; set => canBePicked = value; }
        public Sprite ItemAbilitySprite { get => itemAbilitySprite; }
        public string ItemAbilityName { get => itemAbilityName; set => itemAbilityName = value; }

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

        public virtual void ApplyAbility()
        {
        }

        public virtual void LoseAbility()
        {
        }
    }
}


