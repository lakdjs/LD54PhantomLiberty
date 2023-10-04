using UnityEngine;

namespace PuzzleCandleSystem
{
    public class Candle : MonoBehaviour
    {
        [field: SerializeField] public bool hasCandle { get; private set; } = false;

        public void PutCandle()
        {
            hasCandle = true;
        }
    }
}
