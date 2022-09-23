using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Health), typeof(RagdollActivator))]
    public class Enemy : MonoBehaviour
    {
        private EnemySpot _attachment;
        private Health _health;
        private RagdollActivator _ragdollActivator;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _ragdollActivator = GetComponent<RagdollActivator>();
        }

        public void Init(EnemySpot attachment)
        {
            _attachment = attachment;
        }

        private void OnEnable()
        {
            _health.Died += OnDied;
        }

        private void OnDisable()
        {
            _health.Died -= OnDied;
        }

        public void Enable()
        {
            _health.Enable();
        }

        private void OnDied()
        {
            _attachment.Remove(this);
            
            _ragdollActivator.Activate(true);
        }
    }
}