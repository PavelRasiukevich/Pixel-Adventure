using PixelAdventure.Interfaces;
using System;
using UnityEngine;

namespace PixelAdventure
{
    public class FrogController : BaseController
    {
        private new void Awake()
        {
            base.Awake();
            transform.position = SpawnPosition;
            
        }
    }
}
