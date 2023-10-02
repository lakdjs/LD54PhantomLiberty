using UnityEngine;

namespace PlayerSystem
{
    public class PlayerRayCasts : MonoBehaviour
    {
        private Ray _myRay;
        private RaycastHit _hit;
    
        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider)
            {
              // Debug.Log ($"Target Position: " + hit.collider.gameObject.transform.position+"layer"+hit.transform.gameObject.layer);
            }
        }
    }
}
