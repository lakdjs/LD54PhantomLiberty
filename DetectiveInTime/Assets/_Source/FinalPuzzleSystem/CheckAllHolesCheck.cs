using UnityEngine;

namespace FinalPuzzleSystem
{
    public class CheckAllHolesCheck : MonoBehaviour
    {
        [SerializeField] private FinalPuzzle[] finalPuzzles;
        [SerializeField] private Camera mainCamera;
        private int _quantity = 0;
        private int _factorialQuantity = 1;
        [SerializeField] private GameObject zmurik1;
        [SerializeField] private GameObject zmurik2;
        private void Start()
        {
            for (int i = 0; i < finalPuzzles.Length; i++)
            {
                finalPuzzles[i].OnFragmentAdded += OnFragmentAdded;
                _factorialQuantity *= i + 1;
            }
            Debug.Log(_factorialQuantity);
            zmurik1.SetActive(true);
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

            if (_quantity == _factorialQuantity || _quantity == 10)
            {
                zmurik1.SetActive(false);
                zmurik2.SetActive(true);
                mainCamera.enabled = true;
                gameObject.SetActive(false);
            }
        }
    }
}
