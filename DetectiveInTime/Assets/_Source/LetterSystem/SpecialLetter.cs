using TMPro;
using UnityEngine;

namespace LetterSystem
{
    public class SpecialLetter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private GameObject imageToDisable;
        [SerializeField] private GameObject inventory;
        [SerializeField] private KeyCode pickUpCode;
        [SerializeField] private GameObject numbers;
        private bool _playerInRange = false;
        private bool _isActivated = false;
        private const string PlayerTag = "Player";
        private void Start()
        {
            textMesh.gameObject.SetActive(false);
            imageToDisable.gameObject.SetActive(false);
            _isActivated = false;
            numbers.SetActive(false);
        }

        private void Update()
        {
            if (_playerInRange && Input.GetKeyDown(pickUpCode))
            {
                _isActivated = !_isActivated;
            
                if (_isActivated)
                {
                    numbers.SetActive(true);
                    textMesh.gameObject.SetActive(false);
                    imageToDisable.gameObject.SetActive(true);
                    inventory.gameObject.SetActive(false);
                }
                else
                {
                    textMesh.gameObject.SetActive(true);
                    imageToDisable.gameObject.SetActive(false);
                    inventory.gameObject.SetActive(true);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(PlayerTag))
            {
                _playerInRange = true;
                textMesh.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(PlayerTag))
            {
                _playerInRange = false;
                textMesh.gameObject.SetActive(false);
                if (_isActivated)
                {
                    textMesh.gameObject.SetActive(false);
                    imageToDisable.gameObject.SetActive(false);
                    inventory.gameObject.SetActive(true);
                }
            }
        }
    }
}
