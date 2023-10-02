using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private PlayerInvoker _playerInvoker;
        [SerializeField] private LayerMask _itemLayerMask;
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

        private void OnTriggerStay2D(Collider2D other)
        {
            if ((_itemLayerMask & (1 << other.gameObject.layer)) != 0)
            {
                var item = other.gameObject.GetComponent<ItemInitialize>().item;
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
                var item = other.gameObject.GetComponent<ItemInitialize>().item;
                if (item)
                {
                    _col = null;
                    _colObj = null;
                }
            }
        }
    }
}
