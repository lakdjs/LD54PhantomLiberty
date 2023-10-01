using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class DropItemButton : MonoBehaviour
    {
        [SerializeField] private int buttonIndex;
        [SerializeField] private Inventory inventory;
        [SerializeField] private SpawnItem spawnItem;

        public void Drop()
        {
            if ( inventory.InventoryItems.Count>buttonIndex)
            {
                if (inventory.InventoryItems[buttonIndex] != null)
                {
                    inventory.DeleteItemFromInventory(inventory.InventoryItems[buttonIndex]);   
                }
            }
        }
    }
}
