using System;
using UnityEngine;

namespace FinalPuzzleSystem
{
    public class FinalPuzzle : MonoBehaviour
    {
        public Action<bool> OnFragmentAdded;
        public bool IsInRightHole { get; private set; } = false;
        [SerializeField] private Transform fragment;
        [SerializeField] private string fragmentHole;
        private Vector3 _offset;
        private bool _isDragging = false;
        private Collider2D _dropZone; 
        private bool _isInsideDropZone = false;

        private void OnMouseDown()
        {
            _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isDragging = true;
            _isInsideDropZone = false;
        }

        private void OnMouseDrag()
        {
            if (_isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            }
        }

        private void OnMouseUp()
        {
            _isDragging = false;
            if (_isInsideDropZone)
            {
                transform.position = new Vector3(_dropZone.transform.position.x, _dropZone.transform.position.y, transform.position.z);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DropZone") && other.name == fragmentHole)
            {
                _dropZone = other;
                _isInsideDropZone = true;
                IsInRightHole = true;
                Debug.Log("AAAAp nu davay");
                OnFragmentAdded?.Invoke(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("DropZone"))
            {
                _dropZone = null;
                _isInsideDropZone = false;
            }
        }
    }
}
