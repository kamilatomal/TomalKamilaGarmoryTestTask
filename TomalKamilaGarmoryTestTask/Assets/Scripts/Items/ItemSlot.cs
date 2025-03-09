using System.Collections.Generic;
using Main;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Items
{
    public class ItemSlot : MonoBehaviour
    {
        #region non public fields

        [SerializeField]
        private Image _image;
        [SerializeField]
        private Image _rarityImage;
        [SerializeField] 
        private ItemType _itemType = ItemType.None;
        [SerializeField] 
        private DraggableGameObject _draggableGameObject;
        [SerializeField]
        private bool _isPlayerSlot;

        private ItemData _itemData;
        private ItemConfig _itemConfig;

        #endregion

        #region public fields

        #endregion

        #region non public methods

        private void ClearSlot()
        {
            _itemData = null;
            _itemConfig = null;
            _image.sprite = null;
            _image.enabled = false;
            _rarityImage.sprite = null;
            _rarityImage.enabled = false;
        }
    
        private bool IsSlotValid(ItemType itemType)
        {
            return _itemType == ItemType.None || itemType == _itemType;
        }
    
        private bool OnDragEnd(PointerEventData eventData)
        {
            eventData.position = Input.mousePosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
        
        
            foreach (RaycastResult result in raysastResults)
            {
                if (!result.gameObject.TryGetComponent( out ItemSlot otherItemSlot) || otherItemSlot == this || (!otherItemSlot.IsSlotValid(_itemData.GetItemType())))
                {
                    continue;
                }
                ItemData otherItemData = otherItemSlot._itemData;
                if (otherItemSlot._isPlayerSlot != _isPlayerSlot)
                {
                    ItemData itemToEquip = otherItemSlot._isPlayerSlot ? _itemData : otherItemSlot._itemData; 
                    ItemData itemToUnEquip = otherItemSlot._isPlayerSlot ? otherItemSlot._itemData : _itemData;

                    if (itemToEquip != null)
                    {
                        GameManager.GetInstance().PlayerData.EquipItem(itemToEquip);
                    }

                    if (itemToUnEquip != null)
                    {
                        GameManager.GetInstance().PlayerData.UnEquipItem(itemToUnEquip);
                    }

                }
                otherItemSlot.Setup(_itemData);
                Setup(otherItemData);
                return true;
            }
            return false;
        }
    
        #endregion

        #region public methods
    
        public void Setup(ItemData itemData)
        {
            GameConfig gameConfig = GameManager.GetInstance().GameConfig;
            if (itemData == null)
            {
                ClearSlot();
                return;
            }
            if (!IsSlotValid(itemData.GetItemType()))
            {
                Debug.LogError("ItemData does not match ItemType");
                return;
            }
            _itemData = itemData;
            _itemConfig = gameConfig.GetItemsConfig().GetItemConfig(_itemData.Name);
            if (_itemConfig == null)
            {
                return;
            }
            _image.sprite = _itemConfig.Sprite;
            _image.enabled = true;
            _rarityImage.sprite = gameConfig.GetRarityConfig().GetRaritySprite(_itemData.Rarity);
            _rarityImage.enabled = true;
            _draggableGameObject.Setup(OnDragEnd);
        }
    
        #endregion
    }
}
