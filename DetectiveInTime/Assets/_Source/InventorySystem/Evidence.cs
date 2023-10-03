using UnityEngine;

namespace InventorySystem
{
    public class Evidence : MonoBehaviour
    {
        public int QuantityOfEvidence { get; private set; }

        private void Start()
        {
            QuantityOfEvidence = 0;
        }

        public void AddEvidence()
        {
            QuantityOfEvidence++;
        }
    }
}
