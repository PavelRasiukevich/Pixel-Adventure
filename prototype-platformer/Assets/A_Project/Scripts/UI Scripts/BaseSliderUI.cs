using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public abstract class BaseSliderUI : MonoBehaviour
    {
        protected const int VALUE_MULT = 10;

        public Action<float> VolumeChanged;

        protected TextMeshProUGUI textTMP;
        private Slider slider;

        public Slider Slider { get => slider; set => slider = value; }

        private void Awake()
        {
            slider = GetComponent<Slider>();
            slider.wholeNumbers = true;

            textTMP = GetComponentInChildren<TextMeshProUGUI>();
        }

        public abstract void VolumeChange();
    }
}
