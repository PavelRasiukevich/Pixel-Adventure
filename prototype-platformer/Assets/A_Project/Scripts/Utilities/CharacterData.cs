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
        [SerializeField] float doubleJumpForce;
        [SerializeField] float speed;
        [SerializeField] float dashLenght;
        [SerializeField] float fastFallSpeed;

        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public float DoubleJumpForce { get => doubleJumpForce; set => doubleJumpForce = value; }
        public float Speed { get => speed; set => speed = value; }
        public float DashLenght { get => dashLenght; set => dashLenght = value; }
        public float FastFallSpeed { get => fastFallSpeed; set => fastFallSpeed = value; }
    }
}
