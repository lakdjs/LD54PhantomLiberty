using System;
using InventorySystem;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Player player;
        private PlayerInvoker _playerInvoker;
        [SerializeField] private PlayerCollisionDetector playerCollisionDetector;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private void Awake()
        {
            _playerInvoker = new PlayerInvoker(player);
            playerCollisionDetector.Initialize(
            _playerInvoker,
            player.ItemLayerMask);
        }

        private void Update()
        {
            ReadMove();
        }

        private void ReadMove()
        {
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
            Vector3 moveDirection = new Vector3(horizontal, vertical, 0f );
            _playerInvoker.Move(moveDirection);
        }
    }
}
