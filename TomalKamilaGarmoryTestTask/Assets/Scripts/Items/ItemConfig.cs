using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Item/ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        #region non public fields

        [SerializeField]
        private Sprite _sprite;
        [SerializeField]
        public string ItemName;
    
        #endregion

        #region public fields

        public Sprite Sprite => _sprite;
    
        #endregion

        #region non public methods

        #endregion

        #region public methods
    

        #endregion
    }
}
