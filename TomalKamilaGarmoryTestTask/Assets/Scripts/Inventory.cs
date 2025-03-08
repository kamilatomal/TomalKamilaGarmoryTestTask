using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region non public fields

    [SerializeField] 
    private GameObject _inventoryCanvas;
    [SerializeField] 
    private List<ItemSlot> _itemSlots;
    [SerializeField]
    private int _itemIndexOffsetStep = 4;
    
    private List<ItemData> _items;
    private int _itemIndexOffset;

    #endregion

    #region public fields

    #endregion

    #region non public methods

    private void SetupSlots()
    {
        if (_items == null)
        {
            return;
        }

        for (int i = 0; i < _itemSlots.Count; i++)
        {
            int itemIndex = i + _itemIndexOffset;
            if (_items.Count <= itemIndex)
            {
                _itemSlots[i].Setup(null);
                continue;
            }

            _itemSlots[i].Setup(_items[itemIndex]);
        }
    }

    #endregion

    #region public methods

    public void ToggleInventoryActive()
    {
        _inventoryCanvas.gameObject.SetActive(!_inventoryCanvas.gameObject.activeSelf);
        SetupInventory();
    }

    public void SetupInventory()
    {
        _items = GameManager.GetInstance().PlayerData.GetItemsData().Items;
        _itemIndexOffset = 0;
        SetupSlots();
    }

    public void SetupInventoryWithType(ItemType itemType)
    {
        _items = GameManager.GetInstance().PlayerData.GetItemsData().GetItems(itemType);
        _itemIndexOffset = 0;
        SetupSlots();
    }

    public void SetupInventoryWithType(int itemType)
    {
        SetupInventoryWithType((ItemType)itemType);
    }

    public void PressButtonDown()
    {
        if (_itemIndexOffset + _itemIndexOffsetStep > _items.Count - 1)
        {
            return;
        }

        _itemIndexOffset += _itemIndexOffsetStep;
        SetupSlots();
    }

    public void PressButtonUp()
    {
        _itemIndexOffset -= _itemIndexOffsetStep;
        if (_itemIndexOffset < 0)
        {
            _itemIndexOffset = 0;
        }

        SetupSlots();
    }

    #endregion
}