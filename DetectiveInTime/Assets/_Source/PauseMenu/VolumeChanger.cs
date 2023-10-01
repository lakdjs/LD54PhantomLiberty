using System;
using UnityEngine;
using UnityEngine.UI;

namespace PauseMenu
{
    public class VolumeChanger : MonoBehaviour
    {
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private AudioSource _music;

        

        private void SoundChanger()
        {
            _sound.volume = _soundSlider.value;
            _music.volume = _musicSlider.value;
            Debug.Log($"Sound volume now is {_sound.volume} Music volume now is {_music.volume}");
        }
    }
}
