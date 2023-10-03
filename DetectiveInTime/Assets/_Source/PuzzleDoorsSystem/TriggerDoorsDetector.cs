using System;
using UnityEngine;

namespace PuzzleDoorsSystem
{
    public class TriggerDoorsDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask doorsMask;
        [SerializeField] private Doors doors;
        private GameObject _colObj;
        private Door _door;

        private void Update()
        {
            if (_colObj != null)
            {
                if (Input.GetKeyDown(_door.CodeToOpen))
                {
                    doors.AddNumberInCipher(_door.IndexOfTheDoor);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((doorsMask & (1 << other.gameObject.layer)) != 0)
            {
                _colObj = other.gameObject;
                _door = _colObj.GetComponent<Door>();
               Debug.Log("ep");
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if ((doorsMask & (1 << other.gameObject.layer)) != 0)
            {
                _colObj = null;
                _door = null;
                Debug.Log("nope");
            }
        }
    }
}
