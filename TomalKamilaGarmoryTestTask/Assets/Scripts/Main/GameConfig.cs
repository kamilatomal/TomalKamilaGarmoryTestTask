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
    
        #endregion
    }
}
