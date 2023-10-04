using System;
using UnityEngine;

namespace FinalPuzzleSystem
{
    public class PuzzleActivation : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private KeyCode codeToFinalPuzzle;
        [SerializeField] private GameObject inventory;
        [SerializeField] private GameObject puzzleCamera;
        [SerializeField] private Camera nowCamera;
        [SerializeField] private BoxCollider2D box; 
        private GameObject _playerCol;

        private void Start()
        {
            puzzleCamera.SetActive(false);
        }

        private void Update()
        {
            if (_playerCol != null)
            {
                if (Input.GetKeyDown(codeToFinalPuzzle))
                {
                    Debug.Log("Start");
                    nowCamera.enabled = false;
                    puzzleCamera.SetActive(true);
                    inventory.SetActive(false);
                    box.enabled = false;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((playerLayer & (1 << other.gameObject.layer)) != 0)
            {
                _playerCol = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((playerLayer & (1 << other.gameObject.layer)) != 0)
            {
                _playerCol = null;
            }
        }
    }
}
