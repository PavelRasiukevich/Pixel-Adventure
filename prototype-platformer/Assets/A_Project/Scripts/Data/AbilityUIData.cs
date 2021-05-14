using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class AbilityUIData
    {
        [SerializeField] bool isFastFallIconVisible;
        [SerializeField] bool isDoubleJumpIconVisible;
        [SerializeField] bool isDashIconVisible;

        public bool IsFastFallIconVisible { get => isFastFallIconVisible; set => isFastFallIconVisible = value; }
        public bool IsDoubleJumpIconVisible { get => isDoubleJumpIconVisible; set => isDoubleJumpIconVisible = value; }
        public bool IsDashIconVisible { get => isDashIconVisible; set => isDashIconVisible = value; }
    }
}
