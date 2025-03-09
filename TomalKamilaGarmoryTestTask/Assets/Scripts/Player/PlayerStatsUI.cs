using System.Globalization;
using Main;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerStatsUI : MonoBehaviour
    {
        #region non public fields
    
        [SerializeField]
        private TextMeshProUGUI _damageValueText;
        [SerializeField]
        private TextMeshProUGUI _healthValuePointsText;
        [SerializeField]
        private TextMeshProUGUI _defenseValueText;
        [SerializeField]
        private TextMeshProUGUI _lifeStealValueText;
        [SerializeField]
        private TextMeshProUGUI _criticalChanceValueText;
        [SerializeField]
        private TextMeshProUGUI _attackSpeedValueText;
        [SerializeField]
        private TextMeshProUGUI _movementSpeedValueText;
        [SerializeField]
        private TextMeshProUGUI _luckValueText;
        
        private PlayerData _playerData;
    
        #endregion

        #region public fields

        #endregion

        #region non public methods

        private void OnEnable()
        {
            _playerData = GameManager.GetInstance().PlayerData;
            _playerData.OnStatsUpdated += UpdatePlayerStats;
        }

        private void OnDisable()
        {
            _playerData.OnStatsUpdated -= UpdatePlayerStats;
        }

        private void UpdatePlayerStats()
        {
            _damageValueText.text = $"{_playerData.Damage.ToString()}";
            _healthValuePointsText.text = $"{_playerData.HealthPoints.ToString()}";
            _defenseValueText.text = $"{_playerData.Defense.ToString()}";
            _lifeStealValueText.text = $"{Mathf.Round(_playerData.LifeSteal).ToString(CultureInfo.CurrentCulture)}%";
            _criticalChanceValueText.text = $"{Mathf.Round(_playerData.CriticalChance).ToString(CultureInfo.CurrentCulture)}%";
            _attackSpeedValueText.text = $"{Mathf.Round(_playerData.AttackSpeed).ToString(CultureInfo.InvariantCulture)}%";
            _movementSpeedValueText.text = $"{Mathf.Round(_playerData.MovementSpeed).ToString(CultureInfo.InvariantCulture)}%";
            _luckValueText.text = $"{Mathf.Round(_playerData.Luck).ToString(CultureInfo.InvariantCulture)}%";
        }
        
        #endregion

        #region public methods

        #endregion
    }
}
