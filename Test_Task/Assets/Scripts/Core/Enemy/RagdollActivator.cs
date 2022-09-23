using UnityEngine;

namespace Core
{
    public class RagdollActivator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Collider _collider;
        
        private Rigidbody[] _rigidbodies;

        private void Awake()
        {
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
            
            Activate(false);
        }
        

        public void Activate(bool isActivate)
        {
            _animator.enabled = !isActivate;
            _collider.enabled = !isActivate;

            foreach (Rigidbody rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = !isActivate;
            }
        }
    }
}
