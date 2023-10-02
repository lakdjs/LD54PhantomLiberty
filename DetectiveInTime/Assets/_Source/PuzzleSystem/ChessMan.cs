using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PuzzleSystem
{
    public class ChessMan : MonoBehaviour
    {
        private GameObject _controller;
        [SerializeField] private GameObject movePlate;
        
        private int _xBoard = -1;
        private int _yBoard = -1;
        
        private string _player;
        
        [SerializeField] private Sprite black_queen, black_knight, black_bishop, black_king, black_rook, black_pawn;
        [SerializeField] private Sprite white_queen, white_knight, white_bishop, white_king, white_rook, white_pawn;

        private void Start()
        {
            _controller = GameObject.FindGameObjectWithTag("GameController");
            _controller.GetComponent<GameChess>().OnGameStarted += OnGameStarted;
        }

        void OnGameStarted(GameObject obj) => Destroying();
        public void Destroying()
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        public void Activate()
        {
           // _controller = GameObject.FindGameObjectWithTag("GameController");
            
            SetCoords();
            
            switch (this.name)
            {
                case "black_queen": this.GetComponent<SpriteRenderer>().sprite = black_queen; _player = "black"; break;
                case "black_knight": this.GetComponent<SpriteRenderer>().sprite = black_knight; _player = "black"; break;
                case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = black_bishop; _player = "black"; break;
                case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king; _player = "black"; break;
                case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; _player = "black"; break;
                case "black_pawn": this.GetComponent<SpriteRenderer>().sprite = black_pawn; _player = "black"; break;
                case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; _player = "white"; break;
                case "white_knight": this.GetComponent<SpriteRenderer>().sprite = white_knight; _player = "white"; break;
                case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = white_bishop; _player = "white"; break;
                case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king; _player = "white"; break;
                case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; _player = "white"; break;
                case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn; _player = "white"; break;
            }
        }

        public void SetCoords()
        {
            float x = _xBoard;
            float y = _yBoard;
            
            x *= 0.66f;
            y *= 0.66f;
            
            x += -2.3f;
            y += -2.3f;
            
            this.transform.position = new Vector3(x, y, -1.0f);
        }

        public int GetXBoard()
        {
            return _xBoard;
        }

        public int GetYBoard()
        {
            return _yBoard;
        }

        public void SetXBoard(int x)
        {
            _xBoard = x;
        }

        public void SetYBoard(int y)
        {
            _yBoard = y;
        }

        private void OnMouseUp()
        {
                DestroyMovePlates();
                
                InitiateMovePlates();
        }

        public void DestroyMovePlates()
        {
            GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
            for (int i = 0; i < movePlates.Length; i++)
            {
                Destroy(movePlates[i]);
            }
        }

        public void InitiateMovePlates()
        {
            switch (this.name)
            {
                case "white_queen":
                    LineMovePlate(1, 0);
                    LineMovePlate(0, 1);
                    LineMovePlate(1, 1);
                    LineMovePlate(-1, 0);
                    LineMovePlate(0, -1);
                    LineMovePlate(-1, -1);
                    LineMovePlate(-1, 1);
                    LineMovePlate(1, -1);
                    break;
                case "white_knight":
                    LMovePlate();
                    break;
                case "white_bishop":
                    LineMovePlate(1, 1);
                    LineMovePlate(1, -1);
                    LineMovePlate(-1, 1);
                    LineMovePlate(-1, -1);
                    break;
                case "white_king":
                    SurroundMovePlate();
                    break;
                case "white_rook":
                    LineMovePlate(1, 0);
                    LineMovePlate(0, 1);
                    LineMovePlate(-1, 0);
                    LineMovePlate(0, -1);
                    break;
                case "white_pawn":
                    PawnMovePlate(_xBoard, _yBoard + 1);
                    break;
            }
        }

        public void LineMovePlate(int xIncrement, int yIncrement)
        {
            GameChess sc = _controller.GetComponent<GameChess>();

            int x = _xBoard + xIncrement;
            int y = _yBoard + yIncrement;

            while (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
                x += xIncrement;
                y += yIncrement;
            }

            if (sc.PositionOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<ChessMan>()._player != _player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }

        public void LMovePlate()
        {
            PointMovePlate(_xBoard + 1, _yBoard + 2);
            PointMovePlate(_xBoard - 1, _yBoard + 2);
            PointMovePlate(_xBoard + 2, _yBoard + 1);
            PointMovePlate(_xBoard + 2, _yBoard - 1);
            PointMovePlate(_xBoard + 1, _yBoard - 2);
            PointMovePlate(_xBoard - 1, _yBoard - 2);
            PointMovePlate(_xBoard - 2, _yBoard + 1);
            PointMovePlate(_xBoard - 2, _yBoard - 1);
        }

        public void SurroundMovePlate()
        {
            PointMovePlate(_xBoard, _yBoard + 1);
            PointMovePlate(_xBoard, _yBoard - 1);
            PointMovePlate(_xBoard - 1, _yBoard + 0);
            PointMovePlate(_xBoard - 1, _yBoard - 1);
            PointMovePlate(_xBoard - 1, _yBoard + 1);
            PointMovePlate(_xBoard + 1, _yBoard + 0);
            PointMovePlate(_xBoard + 1, _yBoard - 1);
            PointMovePlate(_xBoard + 1, _yBoard + 1);
        }

        public void PointMovePlate(int x, int y)
        {
            GameChess sc = _controller.GetComponent<GameChess>();
            if (sc.PositionOnBoard(x, y))
            {
                GameObject cp = sc.GetPosition(x, y);

                if (cp == null)
                {
                    MovePlateSpawn(x, y);
                }
                else if (cp.GetComponent<ChessMan>()._player != _player)
                {
                    MovePlateAttackSpawn(x, y);
                }
            }
        }

        public void PawnMovePlate(int x, int y)
        {
            GameChess sc = _controller.GetComponent<GameChess>();
            if (sc.PositionOnBoard(x, y))
            {
                if (sc.GetPosition(x, y) == null)
                {
                    MovePlateSpawn(x, y);
                }

                if (sc.PositionOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<ChessMan>()._player != _player)
                {
                    MovePlateAttackSpawn(x + 1, y);
                }

                if (sc.PositionOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null && sc.GetPosition(x - 1, y).GetComponent<ChessMan>()._player != _player)
                {
                    MovePlateAttackSpawn(x - 1, y);
                }
            }
        }

        public void MovePlateSpawn(int matrixX, int matrixY)
        {
            float x = matrixX;
            float y = matrixY;
            
            x *= 0.66f;
            y *= 0.66f;
            
            x += -2.3f;
            y += -2.4f;

            GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

            MovePlate mpScript = mp.GetComponent<MovePlate>();
            mpScript.SetReference(gameObject);
            mpScript.SetCoords(matrixX, matrixY);
        }

        public void MovePlateAttackSpawn(int matrixX, int matrixY)
        {
            float x = matrixX;
            float y = matrixY;
            
            x *= 0.66f;
            y *= 0.66f;
            
            x += -2.3f;
            y += -2.4f;
            
            GameObject mp = Instantiate(movePlate, new Vector3(x, y, -3.0f), Quaternion.identity);

            MovePlate mpScript = mp.GetComponent<MovePlate>();
            mpScript.attack = true;
            mpScript.SetReference(gameObject);
            mpScript.SetCoords(matrixX, matrixY);
        }
    }
}
