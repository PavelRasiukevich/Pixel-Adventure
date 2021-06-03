using System;
using UnityEngine;

namespace PixelAdventure
{
    public class CameraBoundSwitcher : MonoBehaviour
    {
        [SerializeField] CameraBoundValues values;

        public CameraBoundValues Values { get => values; }
    }

    [Serializable]
    public struct CameraBoundValues
    {
        [SerializeField] float minX, maxX, minY, maxY;

        public float MinX { get => minX; set => minX = value; }
        public float MaxX { get => maxX; set => maxX = value; }
        public float MinY { get => minY; set => minY = value; }
        public float MaxY { get => maxY; set => maxY = value; }

        public CameraBoundValues InitializeDefault()
        {
            minX = -65.0f;
            maxX = 59.0f;
            minY = maxY = -1.0f;

            return this;
        }
    }
}
