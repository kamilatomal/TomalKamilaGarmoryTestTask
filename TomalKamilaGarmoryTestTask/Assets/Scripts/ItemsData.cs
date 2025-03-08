using System.Collections.Generic;

[System.Serializable]
public class ItemsData
{
    #region non public fields

    #endregion

    #region public fields
    
    public List<ItemData> Items;

    #endregion

    #region non public methods

    #endregion

    #region public methods

    public List<ItemData> GetItems(ItemType itemType)
    {
        List<ItemData> result = new List<ItemData>();
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].GetItemType() == itemType)
            {
                result.Add(Items[i]);
            }
        }
        return result;
    }

    #endregion
}