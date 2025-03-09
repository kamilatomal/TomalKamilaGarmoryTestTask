using System;
using System.Collections.Generic;
using Items;

namespace Player
{
    public class PlayerData
    {
        #region non public fields
    
        private ItemsData _itemsData;
        private List<ItemData> _inventory;
        private List<ItemData> _equippedItems;

        private int _rarity;
        private int _damage;
        private int _healthPoints;
        private int _defense;
        private float _lifeSteal;
        private float _criticalChance;
        private float _attackSpeed;
        private float _movementSpeed;
        private float _luck;
        
        #endregion

        #region public fields

        public Action OnStatsUpdated;
        public int Rarity => _rarity;
        public int Damage => _damage;
        public int HealthPoints => _healthPoints;
        public int Defense => _defense;
        public float LifeSteal => _lifeSteal;
        public float CriticalChance => _criticalChance;
        public float AttackSpeed => _attackSpeed;
        public float MovementSpeed => _movementSpeed;
        public float Luck => _luck;
    
        #endregion

        #region non public methods

        private void UpdatePlayerStats()
        {
            _damage = 0;
            _healthPoints = 0;
            _defense = 0;
            _lifeSteal = 0;
            _criticalChance = 0;
            _attackSpeed = 0;
            _movementSpeed = 0;
            _luck = 0;
            
            foreach (ItemData item in _equippedItems)
            {
                _damage += item.Damage;
                _healthPoints += item.HealthPoints;
                _defense += item.Defense;
                _lifeSteal += item.LifeSteal;
                _criticalChance += item.CriticalStrikeChance;
                _attackSpeed += item.AttackSpeed;
                _movementSpeed += item.MovementSpeed;
                _luck += item.Luck;
            }
            OnStatsUpdated?.Invoke();
        }
        
        #endregion

        #region public methods

        public List<ItemData> GetInventory()
        {
            return _inventory;
        }

        public List<ItemData> GetInventory(ItemType itemType)
        {
            List<ItemData> result = new List<ItemData>();
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i].GetItemType() == itemType)
                {
                    result.Add(_inventory[i]);
                }
            }
            return result;
        }

        public void InitPlayer(ItemsData itemsData)
        {
            _itemsData = itemsData;
            _equippedItems = new List<ItemData>();
            _inventory = new List<ItemData>();
            foreach (ItemData item in _itemsData.Items)
            {
                _inventory.Add(item);
            } 
        
            _inventory.Sort((ItemData x, ItemData y) =>
            {
                int typeComparison = x.GetItemType().CompareTo(y.GetItemType());
                if (typeComparison != 0)
                {
                    return typeComparison;
                }
                return String.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            });
        }

        public void EquipItem(ItemData item)
        {
            if (item == null)
            {
                return;
            }
            _inventory.Remove(item);
            _equippedItems.Add(item);
            UpdatePlayerStats();
        }
    
        public void UnEquipItem(ItemData item)
        {
            if (item == null)
            {
                return;
            }
            _equippedItems.Remove(item);
            _inventory.Add(item);
            UpdatePlayerStats();
        }

        public float GetMovementMultiplier()
        {
            return _movementSpeed / 100f;
        }
    
        #endregion
    }
}
