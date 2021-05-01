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

        [SerializeField] float jumpForce;
        [SerializeField] float doubleJumpForce;
        [SerializeField] float dashLenght;
        [SerializeField] float fastFallSpeed;
        [SerializeField] float speed;

        public bool HasDoubleJumpAbility { get => hasDoubleJumpAbility; set => hasDoubleJumpAbility = value; }
        public bool HasDashAbility { get => hasDashAbility; set => hasDashAbility = value; }
        public bool HasFastFallAbility { get => hasFastFallAbility; set => hasFastFallAbility = value; }

        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public float DoubleJumpForce { get => doubleJumpForce; set => doubleJumpForce = value; }
        public float DashLenght { get => dashLenght; set => dashLenght = value; }
        public float FastFallSpeed { get => fastFallSpeed; set => fastFallSpeed = value; }
        public float Speed { get => speed; set => speed = value; }
    }
}
