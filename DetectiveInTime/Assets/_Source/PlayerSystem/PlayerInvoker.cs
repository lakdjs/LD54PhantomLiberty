using UnityEngine;

namespace PlayerSystem
{
    public class PlayerInvoker 
    {
        private PlayerMovement _playerMovement;
        private Player _player;

        public PlayerInvoker(Player player)
        {
            _player = player;
            _playerMovement = new PlayerMovement();
        }

        public void Move(Vector2 moveDir)
        {
            _playerMovement.Move(_player.Rb,_player.MovementSpeed,moveDir);
        }
    }
}
