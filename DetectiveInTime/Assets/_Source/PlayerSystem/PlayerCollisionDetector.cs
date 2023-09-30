using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using PlayerSystem;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    private PlayerInvoker _playerInvoker;
    private LayerMask _itemLayerMask;
    private bool _isItemInTrigger;
    private Item _col;

    private void Update()
    {
        if (_col != null)
        {
            if (Input.GetKeyDown(_col.PickUpCode))
            {
                _playerInvoker.PickUp(_col);
            }
        }
    }

    public void Initialize (PlayerInvoker playerInvoker, LayerMask itemLayerMask)
    {
        _playerInvoker = playerInvoker;
        _itemLayerMask = itemLayerMask;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var item = other.gameObject.GetComponent<ItemInitialize>().item;
        if (item)
        {
            _col = item;
            _isItemInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        var item = other.gameObject.GetComponent<ItemInitialize>().item;
        if (item)
        {
            _col = null;
            _isItemInTrigger = false;
        }
    }
}
