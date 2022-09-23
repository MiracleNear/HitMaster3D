using System.Collections;
using Core.Factories;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        [SerializeField] private float _lifeTime;
        
        private Rigidbody _rigidbody;
        private BulletFactory _bulletFactory;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void Init(BulletFactory bulletFactory, Vector3 position, Quaternion rotation, Vector3 direction)
        {
            _bulletFactory = bulletFactory;
            transform.SetPositionAndRotation(position, rotation);
            _rigidbody.velocity = direction * _speed;

            StartCoroutine(ReclaimWithDelay());
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.Decrease(_damage);
            }
            
            _bulletFactory.Reclaim(this);
        }

        private IEnumerator ReclaimWithDelay()
        {
            yield return new WaitForSeconds(_lifeTime);
            
            _bulletFactory.Reclaim(this);
        }
    }
}