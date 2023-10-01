using PlayerSystem;
using UnityEngine;

namespace InventorySystem
{
    public class SpawnItem : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void SpawnDroppedItem(GameObject item)
        {
            Instantiate(item, _player.gameObject.transform);
        }
    }
}
