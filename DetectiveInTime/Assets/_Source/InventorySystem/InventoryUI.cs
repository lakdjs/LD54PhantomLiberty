using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        [SerializeField] private RectTransform[] itemsPanels;
        [SerializeField] private Sprite inventorySprite;
        [SerializeField] private Sprite inventorySprite2;
        private List<GameObject> _drawnItems = new List<GameObject>(); 
        private void Start()
        {
            inventory.OnItemAdded += OnItemAdded;
            inventory.OnItemDeleted += OnItemDeleted;
            Redraw();

            for (int i = 0; i < itemsPanels.Length; i++)
            {
                if (i % 2 == 0)
                {
                    itemsPanels[i].AddComponent<Image>().sprite = inventorySprite;
                }
                else
                {
                    itemsPanels[i].AddComponent<Image>().sprite = inventorySprite2;
                }
            }
        }

        void OnItemAdded(Item obj) => Redraw();
        void OnItemDeleted(Item obj) => Redraw();

        void Redraw()
        {
            ClearDrawnItems();
            for (int i = 0; i < inventory.InventoryItems.Count; i++)
            {
                var item = inventory.InventoryItems[i];
                var icon = new GameObject("Icon");
                icon.AddComponent<Image>().sprite = item.ItemIcon;
                icon.transform.SetParent(itemsPanels[i]);
                _drawnItems.Add(icon);
            }
        }

        void ClearDrawnItems()
        {
            for (int i = 0; i < _drawnItems.Count; i++)
            {
               Destroy(_drawnItems[i]);
            }
            _drawnItems.Clear();
        }
    }
}
