using SoundSystem;
using UnityEngine;
namespace Pause_Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Sounds bookOpening;
        [SerializeField] private Sounds bookClosing;
        [SerializeField] private KeyCode codeToPause;
        private bool _isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(codeToPause) && _isPaused == false)
            {
                panel.SetActive(true);
                _isPaused = true;
                Time.timeScale = 0;
                bookOpening.PlaySound();
            }
            else if (Input.GetKeyDown(codeToPause) && _isPaused)
            {
                panel.SetActive(false);
                _isPaused = false;
                Time.timeScale = 1;
                bookClosing.PlaySound();
            }
            
        }
    }
}
