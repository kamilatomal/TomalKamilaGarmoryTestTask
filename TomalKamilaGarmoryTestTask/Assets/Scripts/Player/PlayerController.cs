using Main;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        #region non public fields

        [SerializeField]
        private MouseLook _mouseLook;
        [SerializeField] 
        private PlayerMovement _playerMovement;
        [SerializeField] 
        private Inventory _inventory;
        [SerializeField] 
        private Weapon _weapon;
        [SerializeField]
        private HealthController _healthController;
    
        #endregion

        #region public fields
        
        public MouseLook MouseLook => _mouseLook;
        public Inventory Inventory => _inventory;
        public PlayerMovement PlayerMovement => _playerMovement;
        public Weapon Weapon => _weapon;
        public HealthController HealthController => _healthController;

        #endregion

        #region non public methods


        #endregion

        #region public methods

        #endregion
    }
}