using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelAdventure
{
    [Serializable]
    public class AudioData
    {
        [SerializeField] float master;
        [SerializeField] float volume;
        [SerializeField] float sound;

        public float Master { get => master; set => master = value; }
        public float Volume { get => volume; set => volume = value; }
        public float Sound { get => sound; set => sound = value; }
    }
}
