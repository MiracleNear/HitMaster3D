using System;
using System.Collections;
using UnityEngine;

namespace Core
{
    public class GameAttackPhase : MonoBehaviour
    {
        private IPlayerAttacker _player;
   
        public void Init(IPlayerAttacker player)
        {
            _player = player;
        }

        public void StartAttackFrom(EnemySpot enemySpot, Action onEndedAttack)
        {
            StartCoroutine(StartAttackCycle(enemySpot, onEndedAttack));
        }
        
        private IEnumerator StartAttackCycle(EnemySpot enemySpot, Action onEndedAttack)
        {
            Vector3 middlePositionAmongEnemies = enemySpot.GetMiddlePositionAmongEnemies();
            
            enemySpot.Activate();
            
            _player.ActivateShotMode();
            
            _player.LookAt(middlePositionAmongEnemies);

            while (!enemySpot.IsEmpty)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Vector2 mouseScreenPosition = Input.mousePosition;

                    _player.ShootTo(mouseScreenPosition);
                }

                yield return null;
            }
        
            _player.DeactivateShotMode();
            
            onEndedAttack.Invoke();
        }
    }
}