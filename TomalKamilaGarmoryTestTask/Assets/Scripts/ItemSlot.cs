using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    #region non public fields
    
    [SerializeField]
    private Image _image;
    
    [SerializeField] 
    private ItemType _itemType = ItemType.None;

    private ItemData _itemData;
    private ItemConfig _itemConfig;
    #endregion

    #region public fields

    #endregion

    #region non public methods

    #endregion

    #region public methods

    public void Setup(ItemData itemData)
    {
        _itemData = itemData;
        if (_itemData == null)
        {
            ClearSlot();
            return;
        }
        if ( _itemType != ItemType.None && _itemData.GetItemType() != _itemType)
        {
            Debug.LogError("ItemData does not match ItemType");
            return;
        }
        _itemConfig = GameManager.GetInstance().GameConfig.GetItemsConfig().GetItemConfig(_itemData.Name);
        if (_itemConfig == null)
        {
            return;
        }
        _image.sprite = _itemConfig.Sprite;
        _image.enabled = true;
    }

    private void ClearSlot()
    {
        _image.sprite = null;
        _image.enabled = false;
    }
    
    #endregion
}
