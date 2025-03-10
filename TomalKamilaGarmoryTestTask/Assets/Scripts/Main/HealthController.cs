using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Main
{
    public class HealthController : MonoBehaviour
    {
        #region non public fields
        [SerializeField]
        private float _dieDelay;
        [SerializeField]
        private float _maxHealthValue;
        [SerializeField]
        private Image _healthValueImage = null;

        private float _healthValue;
        private Coroutine _dieCoroutine;
        #endregion

        #region public fields
        public UnityEvent OnDealDamage;
        public UnityEvent OnDied;
        #endregion

        #region non public methods
        private void Start()
        {
            _healthValue = _maxHealthValue;
            if (_healthValueImage != null)
            {
                SetHealthBar();
            }
        }

        private IEnumerator Die()
        {
            OnDied?.Invoke();
            yield return new WaitForSeconds(_dieDelay);
            Destroy(gameObject);
        }

        private void SetHealthBar()
        {
            _healthValueImage.fillAmount = _healthValue / _maxHealthValue;
        }
        #endregion

        #region non public methods
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
        #endregion
    }
}