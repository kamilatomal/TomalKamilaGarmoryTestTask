using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    private GameServerMock _gameServerMock;
    private ItemsData _itemsData;
    private Coroutine _initializedCoroutine;

    private void Awake()
    {
         _gameServerMock = new GameServerMock();
    }
    
    public void InitializeData()
    {
        if (_initializedCoroutine != null)
        {
            return;
        }
        _initializedCoroutine = StartCoroutine(InitializeData(GetItemsData, true));
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
        yield return new WaitUntil(() => task.IsCompleted);
        _itemsData = JsonUtility.FromJson<ItemsData>(task.Result);
        onInitialized?.Invoke();
        _initializedCoroutine = null;
    }
    
    public void GetItemsData(ItemsData root)
    {
        foreach (ItemData itemData in root.Items)
        {
            Debug.Log($" \n Name: {itemData.Name} \n Category: {itemData.Category}");
        }
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
        Debug.Log($" \n Name: {itemData.Name} \n Category: {itemData.Category}");
        await Task.Delay(2000);
    }
}