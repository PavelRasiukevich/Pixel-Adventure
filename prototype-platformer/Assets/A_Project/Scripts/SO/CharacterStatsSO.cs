using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [CreateAssetMenu(fileName = "Character Stats", menuName = "Character/Stats")]
    public class CharacterStatsSO : ScriptableObject
    {
        [SerializeField] bool hasDoubleJumpAbility;
        [SerializeField] bool hasDashAbility;

        [SerializeField] float initialJumpForce;
        [SerializeField] float initialDashLenght;
        [SerializeField] float initialSpeed;

        public bool HasDoubleJumpAbility { get => hasDoubleJumpAbility; set => hasDoubleJumpAbility = value; }
        public bool HasDashAbility { get => hasDashAbility; set => hasDashAbility = value; }

        public float InitialJumpForce { get => initialJumpForce; }
        public float InitialSpeed { get => initialSpeed; }
        public float InitialDashLenght { get => initialDashLenght; }
    }
}
