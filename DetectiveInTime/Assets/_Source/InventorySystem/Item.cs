using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "ItemData",menuName = "Tutorial/Item")]
    public class Item : ScriptableObject
    {
        [field: SerializeField] public string ItemName { get; private set; }
        [field: SerializeField] public Sprite ItemIcon { get; private set; }
        [field: SerializeField] public KeyCode PickUpCode { get; private set; }
        
        public override string ToString()
        {
          return this.name;
        }
    }
}
