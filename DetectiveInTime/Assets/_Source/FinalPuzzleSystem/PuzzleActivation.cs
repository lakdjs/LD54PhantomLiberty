using System;
using UnityEngine;

namespace FinalPuzzleSystem
{
    public class PuzzleActivation : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private KeyCode codeToFinalPuzzle;
        [SerializeField] private GameObject inventory;
        private GameObject _playerCol;
        private void Update()
        {
            if (_playerCol != null)
            {
                if (Input.GetKeyDown(codeToFinalPuzzle))
                {
                    Debug.Log("Start");
                    inventory.SetActive(false);
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
