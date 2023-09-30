using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRolling : MonoBehaviour
{
   [SerializeField] private Button rollInventButton;
   [SerializeField] private GameObject[] inventoryImgs;
   [SerializeField] private bool state;

   private void Awake()
   {
      rollInventButton.onClick.AddListener(RollInvent);
   }

   void RollInvent()
   {
      for (int i = 0; i < inventoryImgs.Length; i++)
      {
         inventoryImgs[i].SetActive(state);
      }
      gameObject.SetActive(false);
   }
}
