using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class EnemySpot : MonoBehaviour
    {
        public bool IsEmpty => _allEnemiesInTheArea.Count == 0;

        [SerializeField] private List<Enemy> _allEnemiesInTheArea;

        private void Awake()
        {
            foreach (Enemy enemy in _allEnemiesInTheArea)
            {
                enemy.Init(this);
            }
        }

        public void Activate()
        {
            foreach (Enemy enemy in _allEnemiesInTheArea)
            {
                enemy.Enable();
            }
        }
        
        public Vector3 GetMiddlePositionAmongEnemies()
        {
            Vector3 middlePosition = Vector3.zero;

            foreach (Enemy enemy in _allEnemiesInTheArea)
            {
                middlePosition += enemy.transform.position;
            }

            return middlePosition / _allEnemiesInTheArea.Count;
        }
        
        public void Remove(Enemy enemy)
        {
            _allEnemiesInTheArea.Remove(enemy);
        }
    }
}