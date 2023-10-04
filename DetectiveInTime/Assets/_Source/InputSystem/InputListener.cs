using PlayerSystem;
using SoundSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private PlayerCollisionDetector playerCollisionDetector;
        [SerializeField] private Sounds footSteps;
        private PlayerInvoker _playerInvoker;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        public Animator animator;
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
            Vector2 moveDirection = new Vector3(horizontal, vertical );
            _playerInvoker.Move(moveDirection);
            animator.SetBool("isWalking", moveDirection.magnitude >= 0.4);
        }
    }
}
