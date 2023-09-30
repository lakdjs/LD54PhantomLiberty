using InventorySystem;
using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public Rigidbody2D Rb { get; private set; }
        [field: SerializeField] public LayerMask ItemLayerMask { get; private set; }
        [field: SerializeField] public Inventory Inventory { get; private set; }
        
    }
}
