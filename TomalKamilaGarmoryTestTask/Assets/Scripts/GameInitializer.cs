using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private GameServerMock _gameServerMock;
    private ItemsData _itemsData;
    private Coroutine _initializedCoroutine;
    private CancellationTokenSource _cancellationTokenSource;
    private CancellationToken _cancellationToken;

    private void Awake()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
        _gameServerMock = new GameServerMock();
    }

    public void OnApplicationQuit()
    {
        _cancellationTokenSource.Cancel();
    }

    private IEnumerator InitializeData(Action onInitialized, bool forceReinitialize = false)
    {
        if (_itemsData != null && !forceReinitialize)
        {
            onInitialized?.Invoke();
            _initializedCoroutine = null;
            yield break;
        }
        Task<string> task = _gameServerMock.GetItemsAsync();
        yield return new WaitUntil(() => task.IsCompleted || _cancellationToken.IsCancellationRequested);
        if (_cancellationToken.IsCancellationRequested)
        {
            yield break;
        }
        _itemsData = JsonUtility.FromJson<ItemsData>(task.Result);
        onInitialized?.Invoke();
        _initializedCoroutine = null;
    }
    
    private async void GetItemsData()
    {
        if (_itemsData == null)
        {
            return;
        }
        foreach (ItemData itemData in _itemsData.Items)
        {
            await DebugTest(itemData);
        }
    }

    private async Task DebugTest(ItemData itemData)
    {
        if (_cancellationToken.IsCancellationRequested)
        {
            return;
        }

        Debug.Log($" \n Name: {itemData.Name} \n Category: {itemData.Category}");
        await Task.Delay(1000);
    }
    
    public void PlayGame()
    {
        if (_initializedCoroutine != null)
        {
            return;
        }
        _initializedCoroutine = StartCoroutine(InitializeData(GetItemsData, true));
    }
}