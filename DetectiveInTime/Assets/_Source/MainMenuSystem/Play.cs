using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenuSystem
{
    public class Play : MonoBehaviour
    {
        public string sceneName;
    
        public void SceneChanger()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
