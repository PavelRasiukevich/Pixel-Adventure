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
                        sliders[i].Slider.value = AudioManager.Instance.AudioData.Master / Values.VALUE_MULT;
                        break;
                    case "Music Volume":
                        sliders[i].VolumeChanged += MusicHandler;
                        sliders[i].Slider.value = AudioManager.Instance.AudioData.Volume / Values.VALUE_MULT;
                        break;
                    case "Sound Volume":
                        sliders[i].VolumeChanged += SoundHandler;
                        sliders[i].Slider.value = AudioManager.Instance.AudioData.Sound / Values.VALUE_MULT;
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
            AppPrefs.SetObject(PrefsKeys.AUDIO_DATA, AudioManager.Instance.AudioData);
            Exit(EXIT_TO_BACK_SCREEN);
        }
    }
}
