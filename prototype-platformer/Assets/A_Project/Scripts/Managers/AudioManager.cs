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

        public void PlaySound(AudioClip _clip)
        {
            soundSource.PlayOneShot(_clip);
        }

        public void MasterVolumeChange(float _value)
        {
            mixer.SetFloat("MasterVolume", _value);
            AppPrefs.SetFloat(PrefsKeys.MASTER, _value);
        }

        public void MusicVolumeChange(float _value)
        {
            mixer.SetFloat("MusicVolume", _value);
            AppPrefs.SetFloat(PrefsKeys.MUSIC, _value);
        }

        public void SoundVolumeChange(float _value)
        {
            mixer.SetFloat("SoundVolume", _value);
            AppPrefs.SetFloat(PrefsKeys.SOUND, _value);

        }

    }
}
