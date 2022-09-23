using UnityEngine;

namespace Core
{
    public class Way : MonoBehaviour
    {
        public WayPoint Current => _wayPoints[_currentPointIndex];
        
        [SerializeField] private WayPoint[] _wayPoints;

        private int _currentPointIndex = -1;

        public bool MoveNext()
        {
            _currentPointIndex++;

            if (_currentPointIndex < _wayPoints.Length)
            {
                return true;
            }

            return false;
        }
    }
}