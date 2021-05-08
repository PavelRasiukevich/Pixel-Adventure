using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PixelAdventure
{
    public class AudioManager : BaseManager<AudioManager>
    {
        [SerializeField] AudioMixer mixer;
        [SerializeField] AudioClip clip;

        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource soundSource;

        AudioData audioData;

        public AudioClip Clip { get => clip; set => clip = value; }
        public AudioData AudioData { get => audioData; }

        public void PlayMusic()
        {
            musicSource.clip = Clip;
            musicSource.Play();

        }

        public void SetupVolume()
        {

            if (AppPrefs.HasObject(PrefsKeys.AUDIO_DATA))
            {
                audioData = AppPrefs.GetObject<AudioData>(PrefsKeys.AUDIO_DATA);

                MasterVolumeChange(audioData.Master);
                MusicVolumeChange(audioData.Volume);
                SoundVolumeChange(audioData.Sound);
            }
            else
            {
                audioData = new AudioData();

                MasterVolumeChange(audioData.Master);
                MusicVolumeChange(audioData.Volume);
                SoundVolumeChange(audioData.Sound);

                AppPrefs.SetObject(PrefsKeys.AUDIO_DATA, audioData);
            }
        }

        public void SaveVolumeChanges()
        {
            AppPrefs.SetObject(PrefsKeys.AUDIO_DATA, audioData);
        }

        public void PlaySound(AudioClip _clip)
        {
            soundSource.PlayOneShot(_clip);
        }

        public void MasterVolumeChange(float _value)
        {
            mixer.SetFloat("MasterVolume", _value);
            audioData.Master = _value;
        }

        public void MusicVolumeChange(float _value)
        {
            mixer.SetFloat("MusicVolume", _value);
            audioData.Volume = _value;
        }

        public void SoundVolumeChange(float _value)
        {
            mixer.SetFloat("SoundVolume", _value);
            audioData.Sound = _value;
        }
    }
}
