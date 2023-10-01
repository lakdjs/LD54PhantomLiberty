using System;
using UnityEngine;

namespace PuzzleSystem
{
    public class MovePlate : MonoBehaviour
    {
        [SerializeField] private GameObject controller;
        
        private GameObject _reference = null;

        private int _matrixX;
        private int _matrixY;
        
        //false : movement, true : attacking
        public bool attack = false;

        public void Start()
        {
            if (attack)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }

        public void OnMouseUp()
        {
            controller = GameObject.FindGameObjectWithTag("GameController");

            if (attack)
            {
                GameObject chessPiece = controller.GetComponent<GameChess>().GetPosition(_matrixX, _matrixX);
                Destroy(chessPiece);
            }

            ChessMan chessMan = _reference.GetComponent<ChessMan>();
            controller.GetComponent<GameChess>().SetPositionEmpty(
            chessMan.GetXBoard(),chessMan.GetYBoard());
            
            chessMan.SetXBoard(_matrixX);
            chessMan.SetYBoard(_matrixY);
            chessMan.SetCoordinations();
            
            controller.GetComponent<GameChess>().SetPosition(_reference);

            //chessMan.DestroyMovePlates();
        }

        public void SetCoordinations(int x, int y)
        {
            _matrixX = x;
            _matrixY = y;
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