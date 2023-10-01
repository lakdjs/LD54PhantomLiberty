using System;
using Unity.VisualScripting;
using UnityEngine;

namespace InventorySystem
{
    public class ItemInitialize : MonoBehaviour
    {
        [field: SerializeField] public Item item { get; private set; }
        private KeyCode _itemKeyCode;

        private void Start()
        {
            this.name = item.name;
            this.GetComponent<SpriteRenderer>().sprite = item.ItemIcon;
            _itemKeyCode = item.PickUpCode;
        }
    }
}
