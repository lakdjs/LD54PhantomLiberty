using System;
using UnityEngine;

namespace PuzzleSystem
{
    public class ChessStart : MonoBehaviour
    {

        [SerializeField] private GameChess gameChess;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Camera chessCamera;
        private void OnMouseDown()
        {
           gameChess.gameObject.SetActive(true);
           chessCamera.enabled = true;
           mainCamera.enabled = false;
        }
    }
}
