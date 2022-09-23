using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        private void Awake()
        {
            Disable();
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
        
        public void UpdateBar(float currentHealthPercentage)
        {
            _healthBar.fillAmount = currentHealthPercentage;
        }

        public void LookAt(Transform target)
        {
            transform.LookAt(target);
        }
    }
}