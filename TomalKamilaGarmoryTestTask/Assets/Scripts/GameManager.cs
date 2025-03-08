using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region non public fields

    [SerializeField] 
    private PlayerComponentsContainer _playerComponentsContainer;
    [SerializeField]
    private GameConfig _gameConfig;
    
    private static GameManager _instance;
    private GameServerMock _gameServerMock;
    private PlayerData _playerData;

    private Coroutine _initializedCoroutine;
    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _cancellationToken;

    #endregion

    #region public fields

    public PlayerComponentsContainer PlayerComponentsContainer => _playerComponentsContainer;
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
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
        _gameServerMock = new GameServerMock();
    }


    private IEnumerator InitializeData(Action onInitialized, bool forceReinitialize = false)
    {
        if (_playerData != null && !forceReinitialize)
        {
            onInitialized?.Invoke();
            _initializedCoroutine = null;
            yield break;
        }

        _playerData = new PlayerData();
        yield return StartCoroutine(GetItemsData());
        onInitialized?.Invoke();
        Debug.Log("Game Manager Initialized");
        _initializedCoroutine = null;
        IsInitialized = true;
    }

    private IEnumerator GetItemsData(Action onComplete = null)
    {
        Task<string> task = _gameServerMock.GetItemsAsync();
        yield return new WaitUntil(() => task.IsCompleted || _cancellationToken.IsCancellationRequested);
        if (_cancellationToken.IsCancellationRequested)
        {
            yield break;
        }

        ItemsData itemsData = JsonUtility.FromJson<ItemsData>(task.Result);
        _playerData.SetItemsData(itemsData);
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
    
    public void PlayGame()
    {
        if (_initializedCoroutine != null)
        {
            return;
        }

        _initializedCoroutine = StartCoroutine(InitializeData(null,true));
    }

    #endregion
}