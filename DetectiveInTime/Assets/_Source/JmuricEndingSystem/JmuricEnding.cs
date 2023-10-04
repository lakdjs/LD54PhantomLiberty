using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JmuricEndingSystem
{
    public class JmuricEnding : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private GameObject inventory;
        [SerializeField] private Image blackImage;
        [SerializeField] private int sceneIndex;
        private GameObject _player;

        private void Update()
        {
            if (_player != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    blackImage.gameObject.SetActive(true);
                    StartCoroutine(Ending());
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((playerLayer & (1 << other.gameObject.layer)) != 0)
            {
                _player = other.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if ((playerLayer & (1 << other.gameObject.layer)) != 0)
            {
                _player = null;
            }
        }

        IEnumerator Ending()
        {
            inventory.SetActive(false);
            float speedFading = 0.1f;
            Color black = blackImage.color;
            while (black.a < 1f)
            {
                black.a += speedFading * Time.deltaTime;
                blackImage.color = black;
                yield return null;
            }
            SceneManager.LoadScene(sceneIndex);
            //yield return new WaitForSeconds(5f);
            //SceneManager.LoadScene(sceneIndex);
            
        }
    }
}
