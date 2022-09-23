using System;
using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour, IDamageable
    {
        public Action Died;
        
        [SerializeField] private float _health;
        [SerializeField] private HealthView _healthView;

        private bool _isActive;
        private float _currentHealth;
        private Camera _main;

        private void Awake()
        {
            _currentHealth = _health;
            _main = Camera.main;
        }

        public void Enable()
        {
            _isActive = true;
            
            _healthView.Enable();
        }
        
        public void Decrease(float damage)
        {
            if(!_isActive) return;
            
            _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _health);
            
            _healthView.UpdateBar(_currentHealth / _health);
            
            if (_currentHealth <= 0)
            {
                _isActive = false;
                
                _healthView.Disable();
                
                Died?.Invoke();
            }
        }

        private void LateUpdate()
        {
            if (_isActive)
            {
                _healthView.LookAt(_main.transform);
            }
        }
    }
}