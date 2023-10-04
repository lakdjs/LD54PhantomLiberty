using System;
using System.Collections.Generic;
using InventorySystem;
using SoundSystem;
using UnityEngine;

namespace PuzzleDoorsSystem
{
    public class Doors : MonoBehaviour
    {
        [SerializeField] private int[] finalCipher;
        [SerializeField] private Transform playerPos;
        [SerializeField] private Transform startTeleportPos;
        [SerializeField] private Transform finishTeleportPos;
        [SerializeField] private Transform[] roomTeleportPos;
        [SerializeField] private Item key;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Sounds doorOpening;
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

        void OnDoorOpen(int i) => CheckCipher();
        
        public void AddNumberInCipher(int number)
        {
            _playerCipher.Add(number);
            Debug.Log("Added");
            _onDoorOpen?.Invoke(number);
        }

        private void CheckCipher()
        {
            if (_playerCipher.Count == finalCipher.Length)
            {
                for (int i = 0; i < finalCipher.Length; i++)
                {
                    if (finalCipher[i] != _playerCipher[i])
                    {
                        Debug.Log("Lost");
                        playerPos.position = startTeleportPos.position;
                        doorOpening.PlaySound();
                        _playerCipher.Clear();
                        return;
                    }
                }
                playerPos.position = finishTeleportPos.position;
                doorOpening.PlaySound();
                inventory.AddItemInInventory(key);
                Debug.Log("Won");
            }
            else
            {
                for (int i = 0; i < _playerCipher.Count; i++)
                {
                    if (finalCipher[i] != _playerCipher[i])
                    {
                        Debug.Log("Lost");
                        playerPos.position = startTeleportPos.position;
                        doorOpening.PlaySound();
                        _playerCipher.Clear();
                        return;
                    }
                    playerPos.position = roomTeleportPos[_playerCipher.Count-1].position;
                    doorOpening.PlaySound();
                }
            }
        }
    }
}
