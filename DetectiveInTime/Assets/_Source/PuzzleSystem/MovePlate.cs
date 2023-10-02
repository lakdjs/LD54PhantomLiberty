﻿using System;
using UnityEngine;

namespace PuzzleSystem
{
    public class MovePlate : MonoBehaviour
    {
        private GameObject _controller;
        
        private GameObject _reference = null;
        
        private int _matrixX;
        private int _matrixY;
        
        public bool attack = false;

        private void Update()
        {
        }

        public void Start()
        {
            _controller = GameObject.FindGameObjectWithTag("GameController");
            if (attack)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
        }

        public void OnMouseUp()
        {
           // _controller = GameObject.FindGameObjectWithTag("GameController");
            ChessMan chessMan = _reference.GetComponent<ChessMan>();
            GameChess gameChess = _controller.GetComponent<GameChess>();
            if (attack)
            {
                
                
            }

            
            if (chessMan.name == "white_bishop" && _matrixX == 5 && _matrixY == 6 && attack)
            {
                GameObject cp = gameChess.GetPosition(_matrixX, _matrixY);
                
                Destroy(cp);
                Debug.Log("win");
                gameChess.SetPositionEmpty(chessMan.GetXBoard(), 
                    chessMan.GetYBoard());
            
                chessMan.SetXBoard(_matrixX);
                chessMan.SetYBoard(_matrixY);
                chessMan.SetCoords();
            
                gameChess.SetPosition(_reference);
            
                chessMan.DestroyMovePlates();
            }
            else
            {
                Debug.Log("lose");
                //gameChess.StartingChessGame(null);
            }
            
        }

        public void SetCoords(int x, int y)
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
