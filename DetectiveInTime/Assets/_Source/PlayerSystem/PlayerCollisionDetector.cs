using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using Unity.VisualScripting;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _itemLayerMask;
        [SerializeField] private LayerMask _doorLvlMask;
        [SerializeField] private Inventory inventory;
        private PlayerInvoker _playerInvoker;
        private GameObject _colDoor;
        private bool _isReady;
        private Item _col;
        private GameObject _colObj;
        private List<GameObject> _colObjs = new List<GameObject>();
        private void Update()
        {
            PickingUp();
           
            if (_isReady && Input.GetKeyDown(KeyCode.E))
            {
                gameObject.transform.position = _colDoor.GetComponent<LVLUp>().teleportToPosition.position;
                foreach (Item item in inventory.InventoryItems)
                {
                    if (item.ToString() == "Key")
                    {
                        inventory.DeleteItemFromInventory(item);
                        return;
                    }
                }
            }
        }
        private void PickingUp()
        {
            if (_col != null)
            {
                if (Input.GetKeyDown(_col.PickUpCode))
                {
                    _playerInvoker.PickUp(_col);
                    _colObjs.Add(_colObj);
                    Destroy(_colObj);
                }
            }
        }

        public void Initialize (PlayerInvoker playerInvoker, LayerMask itemLayerMask)
        {
            _playerInvoker = playerInvoker;
            _itemLayerMask = itemLayerMask;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Evidence"))
            {
                Destroy(other.gameObject);
                gameObject.GetComponent<Evidence>().AddEvidence();
            }
            
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            if ((_itemLayerMask & (1 << other.gameObject.layer)) != 0)
            {
                Item item = other.gameObject.GetComponent<ItemInitialize>().item;
                if (item)
                {
                    _col = item;
                    _colObj = other.gameObject;
                }
            }
            if  ((_doorLvlMask & (1 << other.gameObject.layer)) != 0)
            {
                _colDoor = other.GameObject();
                _isReady = _colDoor.GetComponent<LVLUp>().CheckForReady();
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if ((_itemLayerMask & (1 << other.gameObject.layer)) != 0)
            {
                Item item = other.gameObject.GetComponent<ItemInitialize>().item;
                if (item)
                {
                    _col = null;
                    _colObj = null;
                }
            }
            if  ((_doorLvlMask & (1 << other.gameObject.layer)) != 0)
            {
                _colDoor = null;
                _isReady = false;   
            }
        }
    }
}
