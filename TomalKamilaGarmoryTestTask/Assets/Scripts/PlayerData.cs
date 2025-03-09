using System;
using System.Collections.Generic;

public class PlayerData
{
    #region non public fields
    
    private ItemsData _itemsData;
    private List<ItemData> _inventory;
    private List<ItemData> _equippedItems;
    
    #endregion

    #region public fields
    
    #endregion

    #region non public methods

    #endregion

    #region public methods

    public List<ItemData> GetInventory()
    {
        return _inventory;
    }

    public List<ItemData> GetInventory(ItemType itemType)
    {
        List<ItemData> result = new List<ItemData>();
        for (int i = 0; i < _inventory.Count; i++)
        {
            if (_inventory[i].GetItemType() == itemType)
            {
                result.Add(_inventory[i]);
            }
        }
        return result;
    }

    public void InitPlayer(ItemsData itemsData)
    {
        _itemsData = itemsData;
        _equippedItems = new List<ItemData>();
        _inventory = new List<ItemData>();
        foreach (ItemData item in _itemsData.Items)
        {
            _inventory.Add(item);
        } 
        
        _inventory.Sort((ItemData x, ItemData y) =>
        {
            int typeComparison = x.GetItemType().CompareTo(y.GetItemType());
            if (typeComparison != 0)
            {
                return typeComparison;
            }
            return String.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        });
    }

    public void EquipItem(ItemData item)
    {
        if (item == null)
        {
            return;
        }
        _inventory.Remove(item);
        _equippedItems.Add(item);
    }
    
    public void UnEquipItem(ItemData item)
    {
        if (item == null)
        {
            return;
        }
        _equippedItems.Remove(item);
        _inventory.Add(item);
    }
    
    #endregion
}
