using PixelAdventure.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BasePowerUp : MonoBehaviour, IPowerUp
    {
        [SerializeField] protected float value;
        [SerializeField] protected int points;

        Collider2D collider2d;

        void Awake()
        {
            collider2d = GetComponent<Collider2D>();
        }

        public int RewardPoints { get => points; }

        public abstract void AddBonusValue(IControllable _character);

        public void DestroyPowerUp()
        {
            collider2d.enabled = false;
            Destroy(gameObject);
        }
    }
}
