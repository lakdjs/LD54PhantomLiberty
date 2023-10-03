using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PuzzleSystem
{
    public class GameChess : MonoBehaviour
    {
        public Action<GameObject> OnGameStarted;
        
       [SerializeField] private GameObject _chesspiece;
        
        private GameObject[,] _positions = new GameObject[8, 8];
        private GameObject[] _playerBlack = new GameObject[15];
        private GameObject[] _playerWhite = new GameObject[16];
        
        private string _currentPlayer = "white";

        private void Start()
        {
            StartingChessGame(null);
        }

        public void StartingChessGame(GameObject obj)
        {
            OnGameStarted?.Invoke(obj);
            _playerWhite = new GameObject[]
            {
                Create("white_bishop", 2, 0),
                Create("white_bishop", 2, 3), Create("white_queen", 3, 0),
                Create("white_king", 4, 0), Create("white_rook", 7, 0),
                Create("white_rook", 0, 0), Create("white_knight", 1, 0),
                Create("white_knight", 4, 4), Create("white_pawn", 0, 1),
                Create("white_pawn", 1, 1), Create("white_pawn", 2, 1),
                Create("white_pawn", 3, 3), Create("white_pawn", 4, 2),
                Create("white_pawn", 5, 1), Create("white_pawn", 6, 1),
                Create("white_pawn", 7, 1)
            };
            _playerBlack = new GameObject[]
            {
                Create("black_bishop", 5, 7),
                Create("black_bishop", 6, 3), Create("black_queen", 3, 7),
                Create("black_king", 4, 7), Create("black_rook", 7, 7),
                Create("black_rook", 0, 7), Create("black_knight", 1, 7),
                Create("black_knight", 6, 7), Create("black_pawn", 0, 5),
                Create("black_pawn", 1, 6), Create("black_pawn", 2, 6),
                Create("black_pawn", 4, 6), Create("black_pawn", 5, 6),
                Create("black_pawn", 6, 5), Create("black_pawn", 6, 6)
            };

            for (int i = 0; i < _playerBlack.Length; i++)
            {
                SetPosition(_playerBlack[i]);
            }

            for (int i = 0; i < _playerWhite.Length; i++)
            {
                SetPosition(_playerWhite[i]);
            }
        }

        public GameObject Create(string name, int x, int y)
        {
            GameObject obj = Instantiate(_chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
            ChessMan cm = obj.GetComponent<ChessMan>();
            cm.name = name;
            cm.SetXBoard(x);
            cm.SetYBoard(y);
            cm.Activate(); 
            return obj;
        }

        public void SetPosition(GameObject obj)
        {
            ChessMan cm = obj.GetComponent<ChessMan>();
            
            _positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
        }

        public void SetPositionEmpty(int x, int y)
        {
            _positions[x, y] = null;
        }

        public GameObject GetPosition(int x, int y)
        {
            return _positions[x, y];
        }

        public bool PositionOnBoard(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _positions.GetLength(0) || y >= _positions.GetLength(1)) return false;
            return true;
        }

        public string GetCurrentPlayer()
        {
            return _currentPlayer;
        }
    }
}
