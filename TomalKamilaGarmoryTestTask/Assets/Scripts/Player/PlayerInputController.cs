using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        #region non public fields
        [SerializeField]
        private PlayerController _playerController;
        #endregion

        #region public fields

        #endregion

        #region non public methods
        
        #endregion

        #region public methods

        public void OnInventoryOpen(InputAction.CallbackContext context)
        {
            if (context.performed && GameManager.GetInstance().IsInitialized)
            {
                _playerController.Inventory.ToggleInventoryActive();
            }
        }

        public void OnWalk(InputAction.CallbackContext context)
        {
            Vector2 movementDirection = Vector2.zero;
            if (context.performed && GameManager.GetInstance().IsInitialized)
            {
                movementDirection = context.ReadValue<Vector2>();
            }
            _playerController.PlayerMovement.OnWalk(movementDirection);
        }

        #endregion
    }
}