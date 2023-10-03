using InventorySystem;
using PlayerSystem;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LVLUp : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image inventoryBG;
    [SerializeField] private Player player;
    [SerializeField] private int demandEvidenceQuantity;
    [SerializeField] private int demandKeysQuantity;
    [SerializeField] private TMP_Text door;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private KeyCode interactDoorCode;
    [SerializeField] private GameObject monologue;
    [field: SerializeField] public Transform teleportToPosition { get; set; }
    private bool _isReadyForLvl;

    private void Start()
    {
        _isReadyForLvl = false;
        door.gameObject.SetActive(false);
        monologue.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((playerLayer & (1 << other.gameObject.layer)) != 0)
        {
            door.gameObject.SetActive(true); 
        }
        
        if (other.gameObject.GetComponent<Player>())
        {
            CheckForReady();
            if (_isReadyForLvl && Input.GetKeyDown(interactDoorCode))
            {
                player.transform.position = teleportToPosition.position;
            }
            else
            {
                monologue.gameObject.SetActive(true);
                inventoryBG.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((playerLayer & (1 << other.gameObject.layer)) != 0)
        {
            door.gameObject.SetActive(false); 
            monologue.gameObject.SetActive(false);
            inventoryBG.gameObject.SetActive(true);
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
