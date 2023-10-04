using UnityEngine;

namespace SoundSystem
{
    public class Sounds : MonoBehaviour
    {
        [SerializeField] private AudioClip soundClip1;
        [SerializeField] private AudioSource source;

    
        public void PlaySound()
        {
            source.PlayOneShot(soundClip1);
        }
    }
}
