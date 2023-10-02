using System;
using UnityEngine;

namespace PuzzleSystem
{
    public class ChessStart : MonoBehaviour
    {

        [SerializeField] private GameChess gameChess; 
        private void OnMouseDown()
        {
            gameChess.gameObject.SetActive(true);
        }
    }
}
