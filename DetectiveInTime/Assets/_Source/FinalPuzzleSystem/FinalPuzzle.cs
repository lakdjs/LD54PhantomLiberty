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

        private void Update()
        {
            if (_isInsideDropZone)
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                transform.position = new Vector3(_dropZone.transform.position.x, _dropZone.transform.position.y, transform.position.z);
            }
        }

        private void OnMouseDown()
        {
            if (_isInsideDropZone==false)
            {
                _offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _isDragging = true;
                _isInsideDropZone = false;
            }
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
                OnFragmentAdded?.Invoke(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("DropZone"))
            {
                if (gameObject.GetComponent<CircleCollider2D>().enabled)
                {
                    _dropZone = null;
                    _isInsideDropZone = false;
                }
            }
        }
    }
}
