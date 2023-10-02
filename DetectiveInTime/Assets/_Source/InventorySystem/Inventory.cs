using System;
using System.Collections.Generic;
using PlayerSystem;
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
        public List<Item> InventoryItems { get; private set; } = new List<Item>();

        public void AddItemInInventory(Item item,string name)
        {
            if (InventoryItems.Count <= maxInventorySize-1)
            {
                item.ItemName = name;
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
