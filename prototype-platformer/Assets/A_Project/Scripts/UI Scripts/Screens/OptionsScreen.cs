using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class OptionsScreen : BaseScreen
    {
        public const string EXIT_TO_BACK_SCREEN = "EXIT_TO_BACK_SCREEN";

        [SerializeField] SliderUI[] sliders;

        private void Awake()
        {
            sliders = GetComponentsInChildren<SliderUI>();
        }

        public override void ShowScreen()
        {
            base.ShowScreen();

            for (int i = 0; i < sliders.Length; i++)
            {

                switch (sliders[i].name)
                {
                    case "Master Volume":
                        sliders[i].VolumeChanged += MasterHandler;
                        sliders[i].Slider.value = AppPrefs.GetFloat(PrefsKeys.MASTER) / Values.VALUE_MULT;
                        break;
                    case "Music Volume":
                        sliders[i].VolumeChanged += MusicHandler;
                        sliders[i].Slider.value = AppPrefs.GetFloat(PrefsKeys.MUSIC) / Values.VALUE_MULT;
                        break;
                    case "Sound Volume":
                        sliders[i].VolumeChanged += SoundHandler;
                        sliders[i].Slider.value = AppPrefs.GetFloat(PrefsKeys.SOUND) / Values.VALUE_MULT;
                        break;
                }
            }
        }

        private void SoundHandler(float _value)
        {
            AudioManager.Instance.SoundVolumeChange(_value);
        }

        private void MusicHandler(float _value)
        {
            AudioManager.Instance.MusicVolumeChange(_value);
        }

        private void MasterHandler(float _value)
        {
            AudioManager.Instance.MasterVolumeChange(_value);
        }

        public void OnBackPressed()
        {
            Exit(EXIT_TO_BACK_SCREEN);
        }
    }
}
