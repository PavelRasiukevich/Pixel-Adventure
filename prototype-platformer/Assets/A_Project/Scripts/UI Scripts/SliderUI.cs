using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class SliderUI : BaseSliderUI, ISelectHandler, IDeselectHandler
    {

        public void OnSelect(BaseEventData eventData)
        {
            textTMP.enableVertexGradient = true;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            textTMP.enableVertexGradient = false;
        }

        public override void VolumeChange()
        {
            VolumeChanged.Invoke(Slider.value * VALUE_MULT);
        }
    }
}
