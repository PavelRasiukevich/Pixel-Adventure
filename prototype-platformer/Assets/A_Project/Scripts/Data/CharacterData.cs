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
        [SerializeField] Vector2 dashLenght;
        [SerializeField] float fastFallSpeed;
        [SerializeField] bool hasDoubleJump;
        [SerializeField] bool hasDash;
        [SerializeField] bool hasFastFall;
        [SerializeField] float dashReloadTime;
        [SerializeField] float doubleJumpReloadTime;
        [SerializeField] float fastFallReloadTime;

        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public float Speed { get => speed; set => speed = value; }
        public Vector2 DashLenght { get => dashLenght; set => dashLenght = value; }
        public float FastFallSpeed { get => fastFallSpeed; set => fastFallSpeed = value; }
        public bool HasDoubleJump { get => hasDoubleJump; set => hasDoubleJump = value; }
        public bool HasDash { get => hasDash; set => hasDash = value; }
        public bool HasFastFall { get => hasFastFall; set => hasFastFall = value; }
        public float DashReloadTime { get => dashReloadTime; set => dashReloadTime = value; }
        public float DoubleJumpReloadTime { get => doubleJumpReloadTime; set => doubleJumpReloadTime = value; }
        public float FastFallReloadTime { get => fastFallReloadTime; set => fastFallReloadTime = value; }
    }
}
