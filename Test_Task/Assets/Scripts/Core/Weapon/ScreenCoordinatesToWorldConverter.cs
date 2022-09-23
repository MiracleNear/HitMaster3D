using UnityEngine;

namespace Core
{
    public class ScreenCoordinatesToWorldConverter : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public Vector3 GetWorldPositionFrom(Vector2 screenPosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);
            
            Vector3 worldPoint = Vector3.zero;
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                worldPoint = hitInfo.point;
            }
            else
            {
                Vector3 directionLook = transform.forward;
                
                Plane plane = new Plane(directionLook,
                    transform.position + directionLook);

                plane.Raycast(ray, out float enter);

                worldPoint = ray.GetPoint(enter);
            }

            return worldPoint;
        }
    }
}