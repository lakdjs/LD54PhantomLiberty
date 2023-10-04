using System;
using InventorySystem;
using UnityEngine;

namespace ClosetPuzzleSystem
{
    public class ClosetPuzzle : MonoBehaviour
    {
        [SerializeField] private int quantityOfClicks;
        [SerializeField] private GameObject door;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Item key;
        private Action<int> _onClosetClick;

        private void Start()
        {
            door.SetActive(false);
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
                door.SetActive(true);
                gameObject.SetActive(false);
                inventory.AddItemInInventory(key);
            }
        }
    }
}
