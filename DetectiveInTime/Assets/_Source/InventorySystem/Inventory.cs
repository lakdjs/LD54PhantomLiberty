using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public Action<Item> OnItemAdded;
        [SerializeField] private List<Item> startItems = new List<Item>();
        public List<Item> InventoryItems { get; private set; } = new List<Item>();

        private void Start()
        {
            foreach (var item in startItems)
            {
                AddItemInInventory(item);
            }
        }

        public void AddItemInInventory(Item item)
        {
            InventoryItems.Add(item);
            OnItemAdded?.Invoke(item);
        }
    }
}
