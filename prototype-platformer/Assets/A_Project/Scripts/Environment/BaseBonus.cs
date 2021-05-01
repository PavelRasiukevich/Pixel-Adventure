using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseBonus : MonoBehaviour
    {
        [SerializeField] protected AudioClip pickUpSound;
        [SerializeField] protected float bonusValue;
        [SerializeField] protected string bonusName;

        public abstract string BonusName { get; }

        public abstract float AddBonus();
    }
}
