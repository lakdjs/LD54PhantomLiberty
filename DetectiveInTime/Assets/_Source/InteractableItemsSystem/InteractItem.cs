using System;
using UnityEngine;
using TMPro;

namespace InteractableItemsSystem
{
    public class InteractItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemText;
        [SerializeField] private string itemName;
        [SerializeField] private LayerMask playerLayer;
        private void Start()
        {
            itemText.gameObject.SetActive(false);
            itemText.text = itemName;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if ((playerLayer & (1 << other.gameObject.layer)) != 0)
            {
                itemText.gameObject.SetActive(true); 
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if ((playerLayer & (1 << other.gameObject.layer)) != 0)
            {
                itemText.gameObject.SetActive(false); 
            }
        }
    }
}
