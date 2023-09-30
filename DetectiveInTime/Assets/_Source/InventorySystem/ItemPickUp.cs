using UnityEngine;

namespace InventorySystem
{
    public class ItemPickUp 
    {
        public void PickUp(Item item,Inventory inventory)
        {
            inventory.AddItemInInventory(item);
        }
    }
}
