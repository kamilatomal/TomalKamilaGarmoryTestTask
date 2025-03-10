using Player;
using Unity.Cinemachine;
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
        [SerializeField]
        private CinemachineCamera _cinemachineCamera;

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

            var player = Instantiate(_playerControllerPrefab, _playerSpawnPoint);
            _playGameButton.gameObject.SetActive(false);
            _cinemachineCamera.Target.TrackingTarget = player.MouseLook.transform;
        }

        #endregion

        #region public methods

        #endregion
    }
}