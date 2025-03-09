using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Items;
using Player;
using UnityEngine;

namespace Main
{
    public class GameManager : MonoBehaviour
    {
        #region non public fields
        
        [SerializeField] 
        private GameConfig _gameConfig;

        private static GameManager _instance;
        private PlayerData _playerData;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        #endregion

        #region public fields

        public PlayerData PlayerData => _playerData;
        public GameConfig GameConfig => _gameConfig;

        public bool IsInitialized { get; private set; }

        #endregion

        #region non public methods

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }
            _instance = this;
            Initialize();
        }

        private void Initialize()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            StartCoroutine(InitializeData(null,true));
        }

        private IEnumerator InitializeData(Action onInitialized, bool forceReinitialize = false)
        {
            if (_playerData != null && !forceReinitialize)
            {
                onInitialized?.Invoke();
                yield break;
            }

            _playerData = new PlayerData();
            yield return StartCoroutine(GetItemsData());
            onInitialized?.Invoke();
            IsInitialized = true;
        }

        private IEnumerator GetItemsData(Action onComplete = null)
        {
            GameServerMock gameServerMock = new GameServerMock();
            Task<string> task = gameServerMock.GetItemsAsync();
            yield return new WaitUntil(() => task.IsCompleted || _cancellationToken.IsCancellationRequested);
            if (_cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            ItemsData itemsData = JsonUtility.FromJson<ItemsData>(task.Result);
            _playerData.InitPlayer(itemsData);
            onComplete?.Invoke();
        }

        #endregion

        #region public methods

        public static GameManager GetInstance()
        {
            return _instance;
        }

        public void OnApplicationQuit()
        {
            _cancellationTokenSource.Cancel();
        }

        #endregion
    }
}