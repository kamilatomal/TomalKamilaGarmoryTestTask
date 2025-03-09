namespace Items
{
    [System.Serializable]
    public class ItemData
    {
        #region non public fields

        #endregion

        #region public fields

        public string Name;
        public string Category;
        public int Rarity;
        public int Damage;
        public int HealthPoints;
        public int Defense;
        public float LifeSteal;
        public float CriticalStrikeChance;
        public float AttackSpeed;
        public float MovementSpeed;
        public float Luck;

        #endregion

        #region non public methods
    
        private ItemType? _itemType;

        #endregion

        #region public methods

        public ItemType GetItemType()
        {
            if (_itemType.HasValue)
            {
                return _itemType.Value;
            }

            switch (Category)
            {
                case "Armor":
                    _itemType = ItemType.Armor;
                    break;
                case "Boots":
                    _itemType = ItemType.Boots;
                    break;
                case "Helmet":
                    _itemType = ItemType.Helmet;
                    break;
                case "Necklace":
                    _itemType = ItemType.Necklace;
                    break;
                case "Ring":
                    _itemType = ItemType.Ring;
                    break;
                case "Weapon":
                    _itemType = ItemType.Weapon;
                    break;
                default:
                    _itemType = ItemType.None;
                    break;
            }

            return _itemType.Value;
        }

        #endregion
    }
}