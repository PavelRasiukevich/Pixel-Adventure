using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class SliderUI : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        const int VALUE_MULT = 10;

        TextMeshProUGUI textTMP;
        Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            slider.wholeNumbers = true;

            textTMP = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void MasterChange()
        {
            AudioManager.Instance.MasterVolumeChange(slider.value * VALUE_MULT);
        }

        public void MusicChange()
        {
            AudioManager.Instance.MusicVolumeChange(slider.value * VALUE_MULT);
        }

        public void SoundChange()
        {
            AudioManager.Instance.SoundVolumeChange(slider.value * VALUE_MULT);
        }

        public void OnSelect(BaseEventData eventData)
        {
            textTMP.enableVertexGradient = true;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            textTMP.enableVertexGradient = false;
        }
    }
}
