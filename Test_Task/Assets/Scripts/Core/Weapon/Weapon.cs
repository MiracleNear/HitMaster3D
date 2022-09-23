using Core.Factories;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(ScreenCoordinatesToWorldConverter))]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private BulletFactory _bulletFactory;
        [SerializeField] private Transform _launchPoint;

        private ScreenCoordinatesToWorldConverter _screenCoordinatesToWorldConverter;
        private bool _isStartAttackAnimation;

        private void Awake()
        {
            _screenCoordinatesToWorldConverter = GetComponent<ScreenCoordinatesToWorldConverter>();
        }

        public bool CanShoot() => !_isStartAttackAnimation;

        public void Reset()
        {
            _isStartAttackAnimation = false;
        }

        public void Shoot(Vector2 mouseScreenPosition)
        {
            Vector3 worldPoint = _screenCoordinatesToWorldConverter.GetWorldPositionFrom(mouseScreenPosition);

            Vector3 direction = (worldPoint - _launchPoint.position).normalized;

            _bulletFactory.Create(_launchPoint.position, direction, Quaternion.LookRotation(direction));
        }

        private void StartAttackAnimation()
        {
            _isStartAttackAnimation = true;
        }

        private void EndAttackAnimation()
        {
            _isStartAttackAnimation = false;
        }
    }
}