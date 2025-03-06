using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    private GameServerMock _gameServerMock;
    private ItemsData _itemsData;

    private void Awake()
    {
        _gameServerMock = new GameServerMock();
        StartCoroutine(InitializeData());
    }

    private IEnumerator InitializeData()
    {
        Task task = UseGameServerMock();
        yield return new WaitUntil(() => task.IsCompleted);
        Debug.Log("JSON data loaded successfully");
    }

    private async Task UseGameServerMock()
    {
        string jsonString = await _gameServerMock.GetItemsAsync();
        _itemsData = JsonUtility.FromJson<ItemsData>(jsonString);
    }

    [ContextMenu("GetItems")]
    public void GetItemsData()
    {
        foreach (ItemData itemData in _itemsData.Items)
        {
            Debug.Log($" \n Name: {itemData.Name} \n Category: {itemData.Category}");
        }
    }
}