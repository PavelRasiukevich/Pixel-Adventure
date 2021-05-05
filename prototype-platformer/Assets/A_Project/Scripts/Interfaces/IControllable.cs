using System;
using UnityEngine;

namespace PixelAdventure.Interfaces
{
    public interface IControllable
    {
        Action<Transform> OnChangePosition { get; set; }
        Action<Transform> OnPlayerEnable { get; set; }

        Vector3 SpawnPosition { get; set; }
    }
}
