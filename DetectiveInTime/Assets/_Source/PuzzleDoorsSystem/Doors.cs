using System;
using System.Collections.Generic;
using UnityEngine;

namespace PuzzleDoorsSystem
{
    public class Doors : MonoBehaviour
    {
        [SerializeField] private int[] finalCipher;
        private List<int> _playerCipher = new List<int>();
        private Action<int> _onDoorOpen;

        private void Start()
        {
            _onDoorOpen += OnDoorOpen;
        }

        private void Update()
        {
            foreach (var VARIABLE in _playerCipher)
            {
                Debug.Log(VARIABLE);
            }
        }

        void OnDoorOpen(int i) => FinsihThePuzzle();
        
        public void AddNumberInCipher(int number)
        {
            _playerCipher.Add(number);
            Debug.Log("Added");
            _onDoorOpen?.Invoke(number);
        }

        private void FinsihThePuzzle()
        {
            if (_playerCipher.Count == finalCipher.Length)
            {
                Debug.Log("Full cipher");
                for (int i = 0; i < finalCipher.Length; i++)
                {
                    if (finalCipher[i] != _playerCipher[i])
                    {
                        Debug.Log("Lost");
                        return;
                    }
                }
                Debug.Log("Won");
            }
            else
            {
                Debug.Log("not full cipher");
            }
        }
    }
}
