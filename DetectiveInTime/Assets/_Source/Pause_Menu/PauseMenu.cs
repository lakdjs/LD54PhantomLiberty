using SoundSystem;
using UnityEngine;
namespace Pause_Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Sounds bookOpening;
        [SerializeField] private Sounds bookClosing;
        private bool _isPaused = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _isPaused == false)
            {
                panel.SetActive(true);
                _isPaused = true;
                Time.timeScale = 0;
                bookOpening.PlaySound();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused == true)
            {
                panel.SetActive(false);
                _isPaused = false;
                Time.timeScale = 1;
                bookClosing.PlaySound();
            }
            
        }
    }
}
