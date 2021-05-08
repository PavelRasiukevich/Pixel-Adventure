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
        private int index;

        PowerUpStates state;

        public int RewardPoints { get => points; }
        public PowerUpStates State { get => state; set => state = value; }
        public int Index { get => index; set => index = value; }

        public abstract void AddBonusValue();

        public void PickUpPowerUp()
        {
            gameObject.SetActive(false);
            GameInfo.Instance.SetScore(points);
            GameInfo.Instance.SetPowerUpState(Index, PowerUpStates.Consumed);
        }

    }
}
