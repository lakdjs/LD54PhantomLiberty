using System;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _itemLayerMask;
        [SerializeField] private LayerMask _evidenceMask;
        [SerializeField] private LayerMask _doorLvlMask;
        private PlayerInvoker _playerInvoker;
        private Item _col;
        private GameObject _colObj;
        private List<GameObject> _colObjs = new List<GameObject>();
        private void Update()
        {
            PickingUp();
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
            if (other.name == "Evidence")//(_evidenceMask & (1 << other.gameObject.layer)) != 0)
            {
                Destroy(other.gameObject);

                gameObject.GetComponent<Evidence>().AddEvidence();
                Debug.Log(gameObject.GetComponent<Evidence>().QuantityOfEvidence);
            }

            if  ((_doorLvlMask & (1 << other.gameObject.layer)) != 0)
            {
                bool isready = other.GetComponent<LVLUp>().CheckForReady();
                if (isready)
                {
                    gameObject.transform.position = other.GetComponent<LVLUp>().teleportToPosition.position;
                }
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
        }
    }
}
