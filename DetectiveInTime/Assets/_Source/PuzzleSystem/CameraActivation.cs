using UnityEngine;

namespace PuzzleSystem
{
    public class CameraActivation : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        private Camera cam;
        void Start()
        {
            cam = GetComponent<Camera>();
            cam.enabled = false;   
        }

        public void SwitchCameras()
        {
            cam.enabled = !cam.enabled;
            mainCamera.enabled = !mainCamera.enabled;
        }
    }
}
