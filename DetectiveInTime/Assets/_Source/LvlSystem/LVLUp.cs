using InventorySystem;
using PlayerSystem;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LVLUp : MonoBehaviour
{
    [field: SerializeField] public AudioSource MusicSourceOn { get; private set; }
    [field: SerializeField] public AudioSource MusicSourceOff{ get; private set; }
    [field: SerializeField] public KeyCode InteractDoorCode { get; private set; }
    [field: SerializeField] public Transform TeleportToPosition { get; set; }
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image inventoryBG;
    [SerializeField] private Player player;
    [SerializeField] private int demandEvidenceQuantity;
    [SerializeField] private int demandKeysQuantity;
    [SerializeField] private int demandFragmentQuantity;
    [SerializeField] private TMP_Text door;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject monologue;
    private bool _isReadyForLvl;

    private void Start()
    {
        _isReadyForLvl = false;
        door.gameObject.SetActive(false);
        
        if (monologue != null)
        {
            monologue.gameObject.SetActive(false);
        }
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
            if (_isReadyForLvl && Input.GetKeyDown(InteractDoorCode))
            {
                player.transform.position = TeleportToPosition.position;
            }
            else
            {
                if (monologue != null && CheckForReady() == false)
                {
                    monologue.gameObject.SetActive(true); 
                }
                inventoryBG.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((playerLayer & (1 << other.gameObject.layer)) != 0)
        {
            door.gameObject.SetActive(false);
            inventoryBG.gameObject.SetActive(true);
            if (monologue != null)
            {
                monologue.gameObject.SetActive(false);
            }
        }
    }

    public bool CheckForReady()
    {
        int realKeysQuantity = 0;
        int realFragmentQuantity = 0;
        foreach (Item item in inventory.InventoryItems)
        {
            if (item.ToString() == "Key")
            {
                realKeysQuantity++;
            }

            if (item.ToString() == "Fragment" ||
                item.ToString() == "Fragment2" ||
                item.ToString() == "Fragment3" ||
                item.ToString() == "Fragment4")
            {
                realFragmentQuantity++;
            }
        }

        if (player.GetComponent<Evidence>().QuantityOfEvidence >= demandEvidenceQuantity &&
            realKeysQuantity >= demandKeysQuantity &&
            realFragmentQuantity >= demandFragmentQuantity)
        {
            _isReadyForLvl = true;
        }

        return _isReadyForLvl;
    }
}
