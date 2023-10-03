using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string sceneName;
    
    public void SceneChanger()
    {
        SceneManager.LoadScene(sceneName);
    }
}
