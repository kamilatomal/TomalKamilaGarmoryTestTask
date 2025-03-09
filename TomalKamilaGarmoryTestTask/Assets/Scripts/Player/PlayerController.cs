using Main;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        #region non public fields
    
        [SerializeField] 
        private PlayerMovement _playerMovement;
        [SerializeField] 
        private Inventory _inventory;
    
        #endregion

        #region public fields
        
        public Inventory Inventory => _inventory;
        public PlayerMovement PlayerMovement => _playerMovement;
        
        #endregion

        #region non public methods
        

        #endregion

        #region public methods

        
        #endregion
    }
}