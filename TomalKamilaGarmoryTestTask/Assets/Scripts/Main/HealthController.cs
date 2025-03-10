using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Main
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField]
        private float _dieDelay;
        [SerializeField]
        private float _maxHealthValue;
        [SerializeField]
        private Image _healthValueImage;

        private float _healthValue;
        private Coroutine _dieCoroutine;

        public UnityEvent OnDealDamage;
        public UnityEvent OnDied;

        private void Start()
        {
            _healthValue = _maxHealthValue;
            SetHealthBar();
        }

        private IEnumerator Die()
        {
            OnDied?.Invoke();
            yield return new WaitForSeconds(_dieDelay);
            Destroy(gameObject);
        }

        private void SetHealthBar()
        {
            //_healthValueImage.fillAmount = _healthValue / _maxHealthValue;
        }

        public void DealDamage(float damage)
        {
            if (_healthValue > 0)
            {
                _healthValueImage.fillAmount -= damage;
                _healthValue -= damage;
                SetHealthBar();
                OnDealDamage?.Invoke();

                if (_healthValue <= 0)
                {
                    _healthValueImage.fillAmount = 0;
                    if (_dieCoroutine != null)
                    {
                        StopCoroutine(_dieCoroutine);
                    }
                    _dieCoroutine = StartCoroutine(Die());
                }
            }
        }
    }
}