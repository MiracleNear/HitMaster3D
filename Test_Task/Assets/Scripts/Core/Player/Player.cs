using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Weapon), typeof(Animator))]
    public class Player : MonoBehaviour, IPlayerMover, IPlayerAttacker
    {
        public Vector3 Velocity => _navMeshAgent.velocity; 
        
        private NavMeshAgent _navMeshAgent;
        private Weapon _weapon;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _weapon = GetComponent<Weapon>();
        }

        public void MoveTo(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
            
            _animator.SetBool("Walk", true);
        }

        public void StopMove()
        {
            _animator.SetBool("Walk", false);
        }

        public void LookAt(Vector3 position)
        {
            Vector3 directionLook = (position - transform.position).normalized;
            
            transform.rotation = Quaternion.LookRotation(directionLook, Vector3.up);
        }

        public void ActivateShotMode()
        {
            _animator.SetBool("ShootMode", true);
        }

        public void DeactivateShotMode()
        {
            _animator.SetBool("ShootMode", false);
            
            _animator.ResetTrigger("Shoot");
            
            _weapon.Reset();
        }

        public void ShootTo(Vector2 screenPosition)
        {
            if (_weapon.CanShoot())
            {
                _animator.SetTrigger("Shoot");

                _weapon.Shoot(screenPosition);
            }
        }
    }
}