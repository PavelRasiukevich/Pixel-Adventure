using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class CharacterData
    {
        [SerializeField] float jumpForce;
        [SerializeField] float speed;
        [SerializeField] float dashLenght;
        [SerializeField] float fastFallSpeed;
        [SerializeField] bool hasDoubleJump;
        [SerializeField] bool hasDash;

        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public float Speed { get => speed; set => speed = value; }
        public float DashLenght { get => dashLenght; set => dashLenght = value; }
        public float FastFallSpeed { get => fastFallSpeed; set => fastFallSpeed = value; }
        public bool HasDoubleJump { get => hasDoubleJump; set => hasDoubleJump = value; }
        public bool HasDash { get => hasDash; set => hasDash = value; }
    }
}
