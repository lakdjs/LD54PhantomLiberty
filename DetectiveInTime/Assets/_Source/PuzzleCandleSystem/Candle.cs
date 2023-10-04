using UnityEngine;

namespace PuzzleCandleSystem
{
    public class Candle : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer candle;
        [SerializeField] private Sprite fullCandle;

        public void PutCandle()
        {
            candle.sprite = fullCandle;
        }
    }
}
