using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    public abstract class BaseDoor : MonoBehaviour
    {
        public Action OnDoorEntered { get; set; }
        public bool CanEnter { get; set; }
    }
}
