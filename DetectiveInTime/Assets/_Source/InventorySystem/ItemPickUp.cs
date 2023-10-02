using UnityEngine;

namespace InventorySystem
{
    public class ItemPickUp 
    {
        public void PickUp(Item item,Inventory inventory,string name)
        {
            item.ItemName = name;
            inventory.AddItemInInventory(item,name);
        }

        public void Drop(Item item, Inventory inventory)
        {
            inventory.DeleteItemFromInventory(item);
        }
    }
}
