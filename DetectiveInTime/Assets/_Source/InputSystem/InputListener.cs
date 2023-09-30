using System;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Player player;
        private PlayerInvoker _playerInvoker;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private void Awake()
        {
            _playerInvoker = new PlayerInvoker(player);
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
