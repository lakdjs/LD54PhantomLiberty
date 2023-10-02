using System;
using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using PlayerSystem;
using UnityEngine;

public class LVLUp : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Player player;
    [SerializeField] private int demandEvidenceQuantity;
    [SerializeField] private int demandKeysQuantity;
    [field: SerializeField] public Transform teleportToPosition { get; set; }
    private bool _isReadyForLvl;

    private void Start()
    {
        _isReadyForLvl = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            CheckForReady();
            if (_isReadyForLvl)
            {
                player.transform.position = teleportToPosition.position;
            }
        }
    }

    public bool CheckForReady()
    {
        int realKeysQuantity = 0;
        foreach (Item item in inventory.InventoryItems)
        {
            if (item.ToString() == "Key")
            {
                realKeysQuantity++;
            }
        }

        if (player.GetComponent<Evidence>().QuantityOfEvidence == demandEvidenceQuantity &&
            realKeysQuantity >= demandKeysQuantity)
        {
            _isReadyForLvl = true;
        }

        return _isReadyForLvl;
    }
}
