using UnityEngine;

namespace Pause_Menu
{
    public class PlayMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip musicClip;
        [SerializeField] private AudioClip effectClip;

        [SerializeField] private AudioSource source;

        public void PlayEffect()
        {
            source.clip = effectClip;
            source.Play();
        }
    }
}
