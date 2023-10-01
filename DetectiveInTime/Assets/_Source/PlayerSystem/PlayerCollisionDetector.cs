using InventorySystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private PlayerInvoker _playerInvoker;
        private LayerMask _itemLayerMask;
        private Item _col;

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
            var item = other.gameObject.GetComponent<ItemInitialize>().item;
            if (item)
            {
                _col = item;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            var item = other.gameObject.GetComponent<ItemInitialize>().item;
            if (item)
            {
                _col = null;
            }
        }
    }
}
