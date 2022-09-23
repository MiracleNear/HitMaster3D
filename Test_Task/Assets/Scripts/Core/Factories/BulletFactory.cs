using Core.ObjectPool;
using UnityEngine;

namespace Core.Factories
{
    [RequireComponent(typeof(BulletPool))]
    public class BulletFactory : MonoBehaviour
    {
        private IObjectPool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = GetComponent<BulletPool>();
        }

        public void Create(Vector3 position, Vector3 direction, Quaternion rotation)
        {
           Bullet bullet =  _bulletPool.GetFreeElement();
           
           bullet.Init(this, position, rotation, direction);
        }

        public void Reclaim(Bullet bullet)
        {
            _bulletPool.ReturnToPool(bullet);
            
            bullet.StopAllCoroutines();
        }
    }
}