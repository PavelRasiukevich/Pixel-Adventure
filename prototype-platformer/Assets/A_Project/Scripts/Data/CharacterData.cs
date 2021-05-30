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
        [SerializeField] float dashForce;
        [SerializeField] float fastFallSpeed;
        [SerializeField] bool hasDoubleJump;
        [SerializeField] bool hasDash;
        [SerializeField] bool hasFastFall;
        [SerializeField] float dashReloadTime;
        [SerializeField] float doubleJumpReloadTime;
        [SerializeField] float fastFallReloadTime;
        [SerializeField] float dashDuration;
        [SerializeField] bool hasGear;

        [SerializeField] bool hasReloadedDash;
        [SerializeField] bool hasReloadedDoubleJump;
        [SerializeField] bool hasReloadedFastFall;

        [SerializeField] int liveAmount;


        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public float Speed { get => speed; set => speed = value; }
        public float DashForce { get => dashForce; set => dashForce = value; }
        public float FastFallSpeed { get => fastFallSpeed; set => fastFallSpeed = value; }
        public bool HasDoubleJump { get => hasDoubleJump; set => hasDoubleJump = value; }
        public bool HasDash { get => hasDash; set => hasDash = value; }
        public bool HasFastFall { get => hasFastFall; set => hasFastFall = value; }
        public float DashReloadTime { get => dashReloadTime; set => dashReloadTime = value; }
        public float DoubleJumpReloadTime { get => doubleJumpReloadTime; set => doubleJumpReloadTime = value; }
        public float FastFallReloadTime { get => fastFallReloadTime; set => fastFallReloadTime = value; }
        public float DashDuration { get => dashDuration; set => dashDuration = value; }
        public bool HasGear { get => hasGear; set => hasGear = value; }

        public bool HasReloadedDash { get => hasReloadedDash; set => hasReloadedDash = value; }
        public bool HasReloadedDoubleJump { get => hasReloadedDoubleJump; set => hasReloadedDoubleJump = value; }
        public bool HasReloadedFastFall { get => hasReloadedFastFall; set => hasReloadedFastFall = value; }
        public int LiveAmount { get => liveAmount; set => liveAmount = value; }

        public void ResetCooldown()
        {
            hasReloadedDash = true;
            hasReloadedDoubleJump = true;
            hasReloadedFastFall = true;
        }
    }
}
