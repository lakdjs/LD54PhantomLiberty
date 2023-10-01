using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessMan : MonoBehaviour
{
    [SerializeField] private GameObject controller;
    [SerializeField] private GameObject movePlate;
    [SerializeField] private Sprite black_queen, black_king, black_pawn, black_bishop, black_knight, black_rook; 
    [SerializeField] private Sprite white_queen, white_king, white_pawn, white_bishop, white_knight, white_rook;
    [SerializeField] private const string ChessControllerTag = "ChessController";
    private int _xBoard = -1;
    private int _yBoard = -1;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag(ChessControllerTag);
        SetCoordinations();
        switch (this.name)
        {
            case "black_queen": this.GetComponent<SpriteRenderer>().sprite = black_queen;
                break;
            case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king;
                break;
            case "black_pawn": this.GetComponent<SpriteRenderer>().sprite = black_pawn;
                break;
            case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = black_bishop;
                break;
            case "black_knight": this.GetComponent<SpriteRenderer>().sprite = black_knight;
                break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook;
                break;
            
            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen;
                break;
            case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king;
                break;
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn;
                break;
            case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = white_bishop;
                break;
            case "white_knight": this.GetComponent<SpriteRenderer>().sprite = white_knight;
                break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook;
                break;
        }
    }

    public void SetCoordinations()
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
            case "black_queen":
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
            case "black_knight":
            case "white_knight":
               // LMovePlate();
                break;
            case "black_bishop":
            case "white_bishop":
                LineMovePlate(1,1);
                LineMovePlate(1,-1);
                LineMovePlate(-1,1);
                LineMovePlate(-1,-1);
                break;
            case "black_king":
            case "white_king":
                //SurroundMovePlate();
                break;
            case "black_rook":
            case "white_rook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(0, -1);
                LineMovePlate(-1, 0);
                break;
            case "white_pawn":
                //PawnMovePlate(_xBoard, _yBoard + 1);
                break;
        }
    }

    public void LineMovePlate(int xIncr, int yIncr)
    {
        
    }
}
