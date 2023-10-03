using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pause_Menu
{
    public class ButtonValue : MonoBehaviour
    {
        [SerializeField] private Button[] buttons;
        [SerializeField] private Sprite colored;
        [SerializeField] private Sprite unColored;

        private void Start()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().sprite = unColored;
            }
        }

        public void RedrawButton(int value)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i <= value)
                {
                    buttons[i].GetComponent<Image>().sprite = colored;
                }
                else
                {
                    buttons[i].GetComponent<Image>().sprite = unColored;
                }
            }
        }
    }
}
