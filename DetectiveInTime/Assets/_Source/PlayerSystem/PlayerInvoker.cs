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
        private Animator _animator;
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
        }

        public void PickUp(Item item)
        {
            _itemPickUp.PickUp(item,_inventory);
        }

        public void Drop(Item item)
        {
            _itemPickUp.Drop(item,_inventory);
        }
    }
}
