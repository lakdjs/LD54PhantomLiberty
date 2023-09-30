using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "ItemData",menuName = "Tutorial/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string itemName = "Item";
        [field: SerializeField] public Sprite ItemIcon { get; private set; }
        [field: SerializeField] public KeyCode PickUpCode { get; private set; }
    }
}
