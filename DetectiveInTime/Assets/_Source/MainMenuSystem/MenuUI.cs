using UnityEngine;

namespace MainMenuSystem
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject button1;
        [SerializeField] private GameObject button2;

        private void Start()
        {
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(false);
        }

        private void OnMouseOver()
        {
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(true);
        }

        private void OnMouseExit()
        {
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(false);
        }
    }
}
