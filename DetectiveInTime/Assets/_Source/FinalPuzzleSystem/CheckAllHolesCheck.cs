using UnityEngine;

namespace FinalPuzzleSystem
{
    public class CheckAllHolesCheck : MonoBehaviour
    {
        [SerializeField] private FinalPuzzle[] finalPuzzles;
        private int _quantity = 0;
        private int _factorialQuantity = 1;
        private void Start()
        {
            for (int i = 0; i < finalPuzzles.Length; i++)
            {
                finalPuzzles[i].OnFragmentAdded += OnFragmentAdded;
                _factorialQuantity *= i + 1;
            }
            Debug.Log(_factorialQuantity);
        }

        void OnFragmentAdded(bool state) => CheckHoles(); 
        void CheckHoles()
        {
            for (int i = 0; i < finalPuzzles.Length; i++)
            {
                if (finalPuzzles[i].IsInRightHole)
                {
                    _quantity++;
                }
            }

            if (_quantity == _factorialQuantity)
            {
                Debug.Log("Win");
            }
        }
    }
}
