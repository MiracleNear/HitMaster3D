using UnityEngine;

namespace Core
{
    public class WayPointWithEnemy : WayPoint
    {
        [SerializeField] private EnemySpot _enemySpot;
        
        public override void ExecuteEvent()
        {
            GameCycle.StartAttackPhase(_enemySpot);
        }
    }
}