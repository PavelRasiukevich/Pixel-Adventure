using PixelAdventure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BasePowerUp : MonoBehaviour, IPowerUp
    {
        [SerializeField] protected float value;
        [SerializeField] protected int points;
        [SerializeField] GameObject pointsDisplayPrefab;

        protected new string name;
        private int index;

        PowerUpStates state;

        public int RewardPoints { get => points; }
        public PowerUpStates State { get => state; set => state = value; }
        public int Index { get => index; set => index = value; }

        public string GetName => name;

        public abstract void AddBonusValue();

        public void PickUpPowerUp()
        {
            var _pc = Instantiate(pointsDisplayPrefab);
            var _text = _pc.GetComponent<TextMeshPro>();
            _pc.transform.position = transform.position;
            _text.text += $"{points}";
            Destroy(_pc.gameObject, 0.5f);

            GameInfo.Instance.SetScore(points);
            GameInfo.Instance.SetPowerUpState(Index, PowerUpStates.Consumed);
            ActivatePowerUp(false);
        }

        public void ActivatePowerUp(bool _value)
        {
            gameObject.SetActive(_value);
        }
    }
}
