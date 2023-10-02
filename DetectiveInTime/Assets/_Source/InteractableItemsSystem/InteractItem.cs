using System;
using UnityEngine;
using TMPro;

namespace InteractableItemsSystem
{
    public class InteractItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemText;
        [SerializeField] private string itemName;
        private void Start()
        {
            itemText.gameObject.SetActive(false);
            itemText.text = itemName;
        }

        private void OnMouseOver()
        {
            itemText.gameObject.SetActive(true);
        }

        private void OnMouseExit()
        {
            itemText.gameObject.SetActive(false);
        }
    }
}
