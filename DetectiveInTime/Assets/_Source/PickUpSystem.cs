using UnityEngine;
using TMPro;

public class PickUpSystem : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject imageToDisable;
    public GameObject inventory;

    private bool playerInRange = false;
    private bool isActivated = false;

    private void Start()
    {
        textMesh.gameObject.SetActive(false);
        imageToDisable.gameObject.SetActive(false);
        isActivated = false;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            isActivated = !isActivated;
            
            if (isActivated)
            {
                textMesh.gameObject.SetActive(true);
                imageToDisable.gameObject.SetActive(true);
                inventory.gameObject.SetActive(false);
            }
            else
            {
                textMesh.gameObject.SetActive(false);
                imageToDisable.gameObject.SetActive(false);
                inventory.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            textMesh.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            textMesh.gameObject.SetActive(false);
        }
    }
}
