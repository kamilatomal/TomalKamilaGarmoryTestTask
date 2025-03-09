using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class LevelController : MonoBehaviour
    {
        #region non public fields

        [SerializeField] 
        private PlayerController _playerControllerPrefab;
        [SerializeField] 
        private Transform _playerSpawnPoint;
        [SerializeField] 
        private Button _playGameButton;

        #endregion

        #region public fields

        #endregion

        #region non public methods

        private void OnEnable()
        {
            _playGameButton.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            _playGameButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            if (!GameManager.GetInstance().IsInitialized)
            {
                return;
            }

            Instantiate(_playerControllerPrefab, _playerSpawnPoint);
            _playGameButton.gameObject.SetActive(false);
        }

        #endregion

        #region public methods

        #endregion
    }
}