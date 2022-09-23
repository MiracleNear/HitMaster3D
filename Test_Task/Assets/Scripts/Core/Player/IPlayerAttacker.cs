using UnityEngine;

namespace Core
{
    public interface IPlayerAttacker
    {
        public void LookAt(Vector3 position);
        
        public void ActivateShotMode();
        public void DeactivateShotMode();
        public void ShootTo(Vector2 screenPosition);
    }
}