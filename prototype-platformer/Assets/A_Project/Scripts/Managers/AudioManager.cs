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

        public AudioClip Clip { get => clip; set => clip = value; }

        public void PlayMusic()
        {
            musicSource.clip = Clip;
            musicSource.Play();

        }

        public void SetupVolume()
        {
            MasterVolumeChange(GameInfo.Instance.UserData.MasterVolume);
            MusicVolumeChange(GameInfo.Instance.UserData.MusicVolume);
            SoundVolumeChange(GameInfo.Instance.UserData.SoundVolume);
        }

        public void PlaySound(AudioClip _clip)
        {
            soundSource.PlayOneShot(_clip);
        }

        public void MasterVolumeChange(float _value)
        {
            mixer.SetFloat("MasterVolume", _value);
            GameInfo.Instance.UserData.MasterVolume = _value;
        }

        public void MusicVolumeChange(float _value)
        {
            mixer.SetFloat("MusicVolume", _value);
            GameInfo.Instance.UserData.MusicVolume = _value;
        }

        public void SoundVolumeChange(float _value)
        {
            mixer.SetFloat("SoundVolume", _value);
            GameInfo.Instance.UserData.SoundVolume = _value;
        }
    }
}
