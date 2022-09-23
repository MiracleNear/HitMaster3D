using System;
using System.Collections;
using UnityEngine;

namespace Core
{
    public class GameMovementPhase : MonoBehaviour
    {
        private IPlayerMover _playerMover;

        public void Init(IPlayerMover playerMover)
        {
            _playerMover = playerMover;
        }

        public void StartMovingAt(IWayPoint wayPoint, Action onDestination)
        {
            StartCoroutine(WaitingReachDestination(wayPoint.Position, onDestination));
        }
        
        private IEnumerator WaitingReachDestination(Vector3 destination, Action onDestination)
        {
            _playerMover.MoveTo(destination);
            
            yield return new WaitUntil(() => _playerMover.Velocity.sqrMagnitude > float.Epsilon);
            
            yield return new WaitUntil(() => _playerMover.Velocity.sqrMagnitude < float.Epsilon);
            
            _playerMover.StopMove();

            onDestination?.Invoke();
        }
    }
}