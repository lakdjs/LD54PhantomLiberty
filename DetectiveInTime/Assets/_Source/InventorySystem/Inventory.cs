using System;
using System.Collections.Generic;
using PlayerSystem;
using PuzzleSystem;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public Action<Item> OnItemAdded;
        public Action<Item> OnItemDeleted;
        [SerializeField] private List<Item> startItems = new List<Item>();
        [SerializeField] private int maxInventorySize;
        [SerializeField] private Player player;
        [SerializeField] private Item key;
        [SerializeField] private MovePlate movePlate;
        public List<Item> InventoryItems { get; private set; } = new List<Item>();
        
        private void Update()
        {
            foreach (Item item in InventoryItems)
            {
                Debug.Log(item.ToString());
            }
        }

        private void Start()
        {
            foreach (var item in startItems)
            {
                AddItemInInventory(item);
            }
        }
        
        public void AddItemInInventory(Item item)
        {
            if (InventoryItems.Count <= maxInventorySize-1)
            {
                InventoryItems.Add(item);
                OnItemAdded?.Invoke(item);
            }
        }
        public void DeleteItemFromInventory(Item item)
        {
            InventoryItems.Remove(item);
            OnItemDeleted?.Invoke(item);
        }
    }
}
