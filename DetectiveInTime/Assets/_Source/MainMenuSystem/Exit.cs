using UnityEngine;

namespace MainMenuSystem
{
    public class Exit : MonoBehaviour
    {
        public void QuitGame()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
