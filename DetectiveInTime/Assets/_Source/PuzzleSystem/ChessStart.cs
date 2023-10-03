using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace PuzzleSystem
{
    public class ChessStart : MonoBehaviour
    {
        [SerializeField] private GameChess gameChess;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Camera chessCamera;
        [SerializeField] private GameObject inventoryCanvas;
        [SerializeField] private MovePlate movePlate;
        [SerializeField] private KeyCode interactChessCode;
        [SerializeField] private LayerMask pLayerMask;
        private GameObject _playerCollision;

        private void Update()
        {
            if (_playerCollision != null)
            {
                if (Input.GetKeyDown(interactChessCode))
                {
                    if (gameChess != null)
                    {
                        inventoryCanvas.SetActive(false);
                        gameChess.gameObject.SetActive(true);
                        chessCamera.enabled = true;
                        mainCamera.enabled = false;
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((pLayerMask & (1 << other.gameObject.layer)) != 0)
            {
                _playerCollision = other.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((pLayerMask & (1 << other.gameObject.layer)) != 0)
            {
                _playerCollision = null;
            }
        }
    }
}
