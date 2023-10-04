using System.Collections.Generic;
using InventorySystem;
using SoundSystem;
using UnityEngine;
using Unity.VisualScripting;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _itemLayerMask;
        [SerializeField] private LayerMask _doorLvlMask;
        [SerializeField] private LayerMask evidenceMask;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Sounds itemObtainingSound;
        [SerializeField] private Sounds doorOpening;
        private PlayerInvoker _playerInvoker;
        private GameObject _colDoor;
        private bool _isReady;
        private Item _col;
        private GameObject _colObj;
        private List<GameObject> _colObjs = new List<GameObject>();
        private GameObject _evidence;
        private void Update()
        {
            PickingUp();
           
            if (_isReady) 
            {
                LVLUp door = _colDoor.GetComponent<LVLUp>();
                if (Input.GetKeyDown(door.InteractDoorCode))
                {
                     gameObject.transform.position = door.TeleportToPosition.position;
                     doorOpening.PlaySound();
                     if (door.MusicSourceOff != null)
                     {
                         door.MusicSourceOn.Play();
                         door.MusicSourceOff.Stop();
                     }
                     _colDoor.GetComponent<BoxCollider2D>().enabled = false;
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
                    itemObtainingSound.PlaySound();
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
            if ((evidenceMask & (1 << other.gameObject.layer)) != 0)
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
            if ((evidenceMask & (1 << other.gameObject.layer)) != 0)
            {
                Destroy(other.gameObject);
                gameObject.GetComponent<Evidence>().AddEvidence();
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
