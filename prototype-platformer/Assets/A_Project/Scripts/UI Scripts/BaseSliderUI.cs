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

        public  Action VolumeChanged;

        protected TextMeshProUGUI textTMP;
        protected Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            slider.wholeNumbers = true;

            textTMP = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected abstract void VolumeChange();
    }
}
