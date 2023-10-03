using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pause_Menu
{
    public class Volume : MonoBehaviour
    {
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundEffectSlider;
        [SerializeField] private AudioSource[] musicsAudio;
        [SerializeField] private AudioSource[] soundEffectsAudio;
        [SerializeField] private Button[] buttonsForMusic;
        [SerializeField] private Button[] buttonsForEffects;
        private int _firstPlayInt;
        private float _musicsFloat;
        private float _soundEffectsFloat;
        private static readonly string FirstPlay = "FirstPlay";
        private static readonly string MusicPref = "MusicPref";
        private static readonly string SoundEffectsPref = "SoundEffectsPref";
        
        private void Start()
        {
            _firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
            if (_firstPlayInt == 0)
            {
                _musicsFloat = 0.25f;
                _soundEffectsFloat = 0.75f;
                musicSlider.value = _musicsFloat;
                soundEffectSlider.value = _soundEffectsFloat;
                PlayerPrefs.SetFloat(MusicPref,_musicsFloat);
                PlayerPrefs.SetFloat(SoundEffectsPref, _soundEffectsFloat);
                PlayerPrefs.SetInt(FirstPlay, -1);
            }
            else
            {
                _musicsFloat = PlayerPrefs.GetFloat(MusicPref);
                _musicsFloat = PlayerPrefs.GetFloat(MusicPref);
            }
        }

        private void Update()
        {
            
        }

        public void SaveSoundSettings()
        {
           // PlayerPrefs.SetFloat(MusicPref,musicSlider.value);
           // PlayerPrefs.SetFloat(SoundEffectsPref,soundEffectSlider.value);
        }

        private void OnApplicationFocus(bool inFocus)
        {
            if (inFocus)
            {
                SaveSoundSettings();
            }
        }

        public void UpdatingMusic(float value)
        {
            for (int i = 0; i < musicsAudio.Length; i++)
            {
                musicsAudio[i].volume = value;
            }
        }
        public void UpdatingSound(float value)
        {
            for (int i = 0; i < soundEffectsAudio.Length; i++)
            {
                soundEffectsAudio[i].volume = value;
            }
        }
    }
}
