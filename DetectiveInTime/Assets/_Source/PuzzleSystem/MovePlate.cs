using UnityEngine;

namespace PuzzleSystem
{
    public class MovePlate : MonoBehaviour
    {
        private GameObject _controller;
        
        private GameObject _reference = null;
        
        int matrixX;
        int matrixY;
        
        public bool attack = false;

        public void Start()
        {
            if (attack)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
        }

        public void OnMouseUp()
        {
            _controller = GameObject.FindGameObjectWithTag("ChessController");

            GameChess gameChess = _controller.GetComponent<GameChess>();
            if (attack)
            {
                GameObject cp = gameChess.GetPosition(matrixX, matrixY);

                Destroy(cp);
            }
            ChessMan chessMan = _reference.GetComponent<ChessMan>();
            gameChess.SetPositionEmpty(chessMan.GetXBoard(), 
                chessMan.GetYBoard());
            
            chessMan.SetXBoard(matrixX);
            chessMan.SetYBoard(matrixY);
            chessMan.SetCoordinates();
            
            gameChess.SetPosition(_reference);
            
            chessMan.DestroyMovePlates();
        }

        public void SetCoords(int x, int y)
        {
            matrixX = x;
            matrixY = y;
        }

        public void SetReference(GameObject obj)
        {
            _reference = obj;
        }

        public GameObject GetReference()
        {
            return _reference;
        }
    }
}
