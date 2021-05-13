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
        [SerializeField] float initialDashForce;
        [SerializeField] float initialSpeed;

        [SerializeField] float dashReloadTime;
        [SerializeField] float dashDuration;
        [SerializeField] float doubleJumpReloadTime;
        [SerializeField] float fastFallReloadTime;


        public bool HasDoubleJumpAbility { get => hasDoubleJumpAbility; }
        public bool HasDashAbility { get => hasDashAbility; }
        public bool HasFastFallAbility { get => hasFastFallAbility; }

        public float InitialJumpForce { get => initialJumpForce; }
        public float InitialSpeed { get => initialSpeed; }
        public float InitialDashForce { get => initialDashForce; }

        public float DashReloadTime { get => dashReloadTime; }
        public float DoubleJumpReloadTime { get => doubleJumpReloadTime; }
        public float FastFallReloadTime { get => fastFallReloadTime; }
        public float DashDuration { get => dashDuration; }
    }
}
