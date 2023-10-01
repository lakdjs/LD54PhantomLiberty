using System;
using Unity.Mathematics;
using UnityEngine;

namespace PuzzleSystem
{
    public class GameChess : MonoBehaviour
    {
        [SerializeField] private GameObject chessPiece;
        private GameObject[,] positions = new GameObject[8, 8];
        private GameObject[] playerWhite = new GameObject[16];
        private GameObject[] playerBlack = new GameObject[15];

        private string curPlayer = "white";
        private bool gameOver = false;

        private void Start()
        {
            playerWhite = new GameObject[]
            {
                Create("white_bishop", 2, 0), Create("white_bishop", 2, 3), Create("white_queen", 3, 0),
                Create("white_king", 4, 0), Create("white_rook", 7, 0), Create("white_rook", 0, 0),
                Create("white_knight", 1, 0), Create("white_knight", 4, 4), Create("white_pawn", 0, 1),
                Create("white_pawn", 1, 1), Create("white_pawn", 2, 1), Create("white_pawn", 3, 3),
                Create("white_pawn", 4, 2), Create("white_pawn", 5, 1), Create("white_pawn", 6, 1),
                Create("white_pawn", 7, 1)
            };
            playerBlack = new GameObject[]
            {
                Create("black_bishop", 5, 7), Create("black_bishop", 6, 3), Create("black_queen", 3, 7),
                Create("black_king", 4, 7), Create("black_rook", 7, 7), Create("black_rook", 0, 7),
                Create("black_knight", 1, 7), Create("black_knight", 6, 7), Create("black_pawn", 0, 5),
                Create("black_pawn", 1, 6), Create("black_pawn", 2, 6), Create("black_pawn", 4, 6),
                Create("black_pawn", 5, 6), Create("black_pawn", 6, 5), Create("black_pawn", 6, 6)
            };
            for (int i = 0; i < playerBlack.Length; i++)
            {
                SetPosition(playerBlack[i]);
            }

            for (int i = 0; i < playerWhite.Length; i++)
            {
                SetPosition(playerWhite[i]);
            }
        }

        public GameObject Create(string name, int x, int y)
        {
            GameObject obj = Instantiate(chessPiece, new Vector3(0, 0, -1), Quaternion.identity);
            ChessMan chessMan = obj.GetComponent<ChessMan>();
            chessMan.name = name;
            chessMan.SetXBoard(x);
            chessMan.SetYBoard(y);
            chessMan.Activate();
            return obj;
        }

        public void SetPosition(GameObject obj)
        {
            ChessMan chessMan = obj.GetComponent<ChessMan>();
            positions[chessMan.GetXBoard(), chessMan.GetYBoard()] = obj;
        }

        public void SetPositionEmpty(int x, int y)
        {
            positions[x,y] = null;
        }

        public GameObject GetPosition(int x, int y)
        {
            return positions[x, y];
        }

        public bool PositionOnBoard(int x, int y)
        {
            if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1))
            {
                return false;   
            }
            return true;
        }
    }
}
