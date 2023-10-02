using System;
using UnityEngine;

namespace PuzzleClosetSystem
{
    public class Closet : MonoBehaviour
    {
        [SerializeField] private int quantityOfClicks;
        private Action<int> _onClosetClick;

        private void Start()
        {
            _onClosetClick += OnClickAdd;
        }

        void OnClickAdd(int i) => OpenTheDoor();
        private void OnMouseDown()
        {
            --quantityOfClicks;
            _onClosetClick?.Invoke(quantityOfClicks);
        }

        private void OpenTheDoor()
        {
            if (quantityOfClicks <= 0)
            {
                Debug.Log("u won");
            }
        }
    }
}
