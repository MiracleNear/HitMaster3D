using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameCycle : MonoBehaviour
    {
        [SerializeField] private Way _way;
        [SerializeField] private GameObject _playerContainer;
        [SerializeField] private GameAttackPhase _gameAttackPhase;
        [SerializeField] private GameMovementPhase _gameMovementPhase;
        
        
        private void OnValidate()
        {
            if (_playerContainer != null && _playerContainer.GetComponent<Player>() == null)
            {
                _playerContainer = null;
            }
        }

        private void Awake()
        {
            Player player = _playerContainer.GetComponent<Player>();
            
            _gameAttackPhase.Init(player);
            _gameMovementPhase.Init(player);
        }
        
        
        public void LaunchFirstStep()
        {
            Step();
        }

        public void Finish()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartAttackPhase(EnemySpot enemySpot)
        {
            _gameAttackPhase.StartAttackFrom(enemySpot, OnEndedGameAttackPhase);
        }

        private void OnEndedGameAttackPhase()
        {
            Step();
        }

        private void Step()
        {
            if (_way.MoveNext())
            {
                _gameMovementPhase.StartMovingAt(_way.Current, OnDestinationCurrentWayPoint);
            }
        }

        private void OnDestinationCurrentWayPoint()
        { 
            _way.Current.ExecuteEvent();
        }
    }
}