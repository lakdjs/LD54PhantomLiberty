using InventorySystem;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerInvoker 
    {
        private PlayerMovement _playerMovement;
        private Player _player;
        private ItemPickUp _itemPickUp;
        private Inventory _inventory;
        public PlayerInvoker(Player player)
        {
            _player = player;
            _inventory = _player.Inventory;
            _playerMovement = new PlayerMovement();
            _itemPickUp = new ItemPickUp();
        }

        public void Move(Vector2 moveDir)
        {
            _playerMovement.Move(_player.Rb, _player.MovementSpeed, moveDir);
            if (moveDir.x > 0)
            {
                _player.transform.localScale = new Vector3(-Mathf.Abs(_player.transform.localScale.x), _player.transform.localScale.y, _player.transform.localScale.z);
            }
            else if (moveDir.x < 0)
            {
                _player.transform.localScale = new Vector3(Mathf.Abs(_player.transform.localScale.x), _player.transform.localScale.y, _player.transform.localScale.z);
            }
        }

        public void PickUp(Item item,string name)
        {
            _itemPickUp.PickUp(item,_inventory,name);
            
        }

        public void Drop(Item item)
        {
            _itemPickUp.Drop(item,_inventory);
        }
    }
}
