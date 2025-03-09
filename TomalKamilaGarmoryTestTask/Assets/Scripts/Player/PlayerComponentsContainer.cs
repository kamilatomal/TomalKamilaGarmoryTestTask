using Main;
using UnityEngine;

namespace Player
{
    public class PlayerComponentsContainer : MonoBehaviour
    {
        #region non public fields

        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private PlayerInputController _playerInputController;

        #endregion

        #region public fields

        public Inventory Inventory => _inventory;
        public PlayerMovement PlayerMovement => _playerMovement;
        public PlayerInputController PlayerInputController => _playerInputController;

        #endregion

        #region non public methods

        #endregion

        #region public methods

        #endregion
    }
}