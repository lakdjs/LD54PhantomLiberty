using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pause_Menu
{
    public class Volume : MonoBehaviour
    {
        private static readonly string _firstPlay = "FirstPlay";
        private static readonly string _musicPref = "MusicPref";
        private static readonly string _soundEffectsPref = "SoundEffectsPref";
        private int firstPlayInt;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundEffectSlider;
        private float _musicsFloat;
        private float _soundEffectsFloat;
        [SerializeField] private AudioSource[] musicsAudio;
        [SerializeField] private AudioSource[] soundEffectsAudio;

        private void Start()
        {
            firstPlayInt = PlayerPrefs.GetInt(_firstPlay);
            if (firstPlayInt == 0)
            {
                _musicsFloat = 0.25f;
                _soundEffectsFloat = 0.75f;
                musicSlider.value = _musicsFloat;
                soundEffectSlider.value = _soundEffectsFloat;
                PlayerPrefs.SetFloat(_musicPref,_musicsFloat);
                PlayerPrefs.SetFloat(_soundEffectsPref, _soundEffectsFloat);
                PlayerPrefs.SetInt(_firstPlay, -1);
            }
            else
            {
                _musicsFloat = PlayerPrefs.GetFloat(_musicPref);
                musicSlider.value = _musicsFloat;
                _musicsFloat = PlayerPrefs.GetFloat(_musicPref);
                soundEffectSlider.value = _soundEffectsFloat;
            }
        }

        public void SaveSoundSettings()
        {
            PlayerPrefs.SetFloat(_musicPref,musicSlider.value);
            PlayerPrefs.SetFloat(_soundEffectsPref,soundEffectSlider.value);
        }

        private void OnApplicationFocus(bool inFocus)
        {
            if (inFocus)
            {
                SaveSoundSettings();
            }
        }

        public void UpdatingSound()
        {
            for (int i = 0; i < musicsAudio.Length; i++)
            {
                musicsAudio[i].volume = musicSlider.value;
            }
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = soundEffectSlider.value;
            }
        }
    }
}
