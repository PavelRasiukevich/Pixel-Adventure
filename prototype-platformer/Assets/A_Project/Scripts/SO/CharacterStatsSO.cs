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
        [SerializeField] bool hasFastFallAbility;

        [SerializeField] float initialJumpForce;
        float currentJumpForce;
        [SerializeField] float initialDoubleJumpForce;
        float currentDoubleJumpForce;
        [SerializeField] float initialFastFallSpeed;
        float currentFastFallSpeed;
        [SerializeField] float initialDashLenght;
        float currentDashLenght;
        [SerializeField] float initialSpeed;
        float currentSpeed;

        public bool HasDoubleJumpAbility { get => hasDoubleJumpAbility; set => hasDoubleJumpAbility = value; }
        public bool HasDashAbility { get => hasDashAbility; set => hasDashAbility = value; }
        public bool HasFastFallAbility { get => hasFastFallAbility; set => hasFastFallAbility = value; }

        public float CurrentJumpForce { get => currentJumpForce; set => currentJumpForce = value; }
        public float InitialJumpForce { get => initialJumpForce; }
        public float InitialDoubleJumpForce { get => initialDoubleJumpForce; }
        public float InitialFastFallSpeed { get => initialFastFallSpeed; }
        public float CurrentFastFallSpeed { get => currentFastFallSpeed; set => currentFastFallSpeed = value; }
        public float CurrentDoubleJumpForce { get => currentDoubleJumpForce; set => currentDoubleJumpForce = value; }
        public float InitialSpeed { get => initialSpeed; }
        public float CurrentSpeed { get => currentSpeed; set => currentSpeed = value; }
        public float InitialDashLenght { get => initialDashLenght; }
        public float CurrentDashLenght { get => currentDashLenght; set => currentDashLenght = value; }
    }
}
