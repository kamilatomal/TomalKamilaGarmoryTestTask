public class PlayerData
{
    #region non public fields
    
    private ItemsData _itemsData;
    
    #endregion

    #region public fields
    
    #endregion

    #region non public methods

    #endregion

    #region public methods

    public ItemsData GetItemsData()
    {
        return _itemsData;
    }

    public void SetItemsData(ItemsData itemsData)
    {
        _itemsData = itemsData;
    }

    #endregion
}
