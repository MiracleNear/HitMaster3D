using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public class GameStarter : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private Canvas _mainCanvas;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _gameCycle.LaunchFirstStep();
            
            _mainCanvas.gameObject.SetActive(false);
        }
    }
}