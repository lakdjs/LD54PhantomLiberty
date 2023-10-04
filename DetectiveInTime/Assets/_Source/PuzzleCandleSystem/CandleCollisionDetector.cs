using System;
using InventorySystem;
using UnityEngine;

namespace PuzzleCandleSystem
{
    public class CandleCollisionDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask candleShelfLayer;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Candle candle;
        [SerializeField] private Item key;
        private GameObject _candleCollision;
        private Candle _candle;
        private void Update()
        {
            if (_candleCollision != null)
            {
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                   foreach (Item item in inventory.InventoryItems)
                   {
                       if (item.ToString() == "Candle")
                       {
                           inventory.DeleteItemFromInventory(item);
                           candle.PutCandle();
                           inventory.AddItemInInventory(key);
                           return;
                       }
                   }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((candleShelfLayer & (1 << other.gameObject.layer)) != 0)
            {
                _candleCollision = other.gameObject;
                _candle = other.gameObject.GetComponent<Candle>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((candleShelfLayer & (1 << other.gameObject.layer)) != 0)
            {
                _candleCollision = null;
                _candle = null;
            }
        }
    }
}
