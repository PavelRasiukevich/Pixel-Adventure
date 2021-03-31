using System;
using UnityEngine;

namespace PixelAdventure.Interfaces
{
    public interface IControllable
    {
       Action<Transform> OnChangePosition { get; set; }
    }
}
