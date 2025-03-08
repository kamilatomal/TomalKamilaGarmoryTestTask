using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region non public fields

    [SerializeField]
    private GameObject _inventoryCanvas;
    [SerializeField]
    private List<ItemSlot> _itemSlots;
    
    #endregion

    #region public fields

    #endregion

    #region non public methods

    #endregion

    #region public methods

    public void SetInventoryActive()
    {
        _inventoryCanvas.gameObject.SetActive(!_inventoryCanvas.gameObject.activeSelf);
    }

    #endregion
    
}