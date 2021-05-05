using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BasePowerUp : MonoBehaviour, IPowerUp
    {
        [SerializeField] protected float value;
        [SerializeField] protected int points;
        [SerializeField] private int index;

        PowerUpStates state;

        Collider2D collider2d;

        public int RewardPoints { get => points; }
        public PowerUpStates State { get => state; set => state = value; }
        public int Index { get => index; set => index = value; }

        void Awake()
        {
            collider2d = GetComponent<Collider2D>();
        }

        public abstract void AddBonusValue(IControllable _character);

        public  void PickUpPowerUp()
        {
            gameObject.SetActive(false);
            GameInfo.Instance.SetPowerUpState(Index, PowerUpStates.Consumed);
        }
      
    }
}
