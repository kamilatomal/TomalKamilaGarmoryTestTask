using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "ItemsConfig", menuName = "Item/ItemsConfig")]
    public class ItemsConfig : ScriptableObject
    {
        #region non public fields

        [SerializeField]
        private List<ItemConfig> _itemConfigs = new List<ItemConfig>();
    
        private Dictionary<string, ItemConfig> _itemConfigsDict;
    
        #endregion

        #region public fields
    

        #endregion

        #region non public methods
    
        private void InitializeItemsDict()
        {
            _itemConfigsDict = new Dictionary<string, ItemConfig>();
            foreach (var itemConfig in _itemConfigs)
            {
                if (!_itemConfigsDict.TryAdd(itemConfig.ItemName, itemConfig))
                {
                    Debug.LogWarning("You try to add existing itemConfig");
                }
            }
        }

        #endregion

        #region public methods
    
        public ItemConfig GetItemConfig(string itemName)
        {
            if (_itemConfigsDict == null)
            {
                InitializeItemsDict();
            }
        
            return _itemConfigsDict![itemName];
        }
    
        #endregion
    }
}
