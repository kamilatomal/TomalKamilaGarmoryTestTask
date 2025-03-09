using UnityEngine;

namespace Items
{
    [System.Serializable]
    public class RarityWithSprite
    {
        #region non public fields

        [SerializeField]
        private int _rarity;
        [SerializeField]
        private Sprite _sprite;
        [SerializeField] 
        private string _name;
    
        #endregion

        #region public fields

        public int Rarity => _rarity;
        public Sprite Sprite => _sprite;
        public string Name => _name;
        
        #endregion

        #region non public methods


        #endregion

        #region public methods


        #endregion
   
    }
}