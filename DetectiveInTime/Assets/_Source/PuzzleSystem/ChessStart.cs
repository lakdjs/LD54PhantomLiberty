using System;
using UnityEngine;

namespace PuzzleSystem
{
    public class ChessStart : MonoBehaviour
    {
        [SerializeField] private GameChess gameChess;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Camera chessCamera;
        [SerializeField] private GameObject inventoryCanvas;
        [SerializeField] private MovePlate movePlate;
        

        private void OnMouseDown()
        { 
           inventoryCanvas.SetActive(false);
           gameChess.gameObject.SetActive(true);
           chessCamera.enabled = true;
           mainCamera.enabled = false;
        }
        
    }
}
