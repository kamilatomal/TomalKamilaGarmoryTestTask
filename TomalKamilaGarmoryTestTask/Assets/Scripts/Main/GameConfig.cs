using Items;
using UnityEngine;

namespace Main
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        #region non public fields

        [SerializeField]
        private ItemsConfig _itemsConfig;
        
        [SerializeField]
        private RarityConfig _rarityConfig;
  
        #endregion

        #region public fields
        
        #endregion

        #region non public methods

        #endregion

        #region public methods
    
        public ItemsConfig GetItemsConfig()
        {
            return _itemsConfig;
        }
        
        public RarityConfig GetRarityConfig()
        {
            return _rarityConfig;
        }
    
        #endregion
    }
}
