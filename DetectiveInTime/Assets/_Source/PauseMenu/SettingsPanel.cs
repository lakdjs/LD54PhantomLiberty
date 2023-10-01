using UnityEngine;

namespace PauseMenu
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _settingsPanel;
        private bool _isActive = false;
        public void SettingsPanelOn()
        {
                _settingsPanel.SetActive(true);
        }
    }
}
