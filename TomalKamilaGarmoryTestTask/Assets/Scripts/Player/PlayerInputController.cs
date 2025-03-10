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
            Vector2 movementVector = Vector2.zero;
            if (context.performed && !_playerController.Inventory.IsInventoryOpen && GameManager.GetInstance().IsInitialized)
            {
                movementVector = context.ReadValue<Vector2>();
                _playerController.PlayerMovement.SetCanMove(true);
                _playerController.PlayerMovement.OnWalk(movementVector);
            }
            
            if (context.canceled)
            {
                _playerController.PlayerMovement.SetCanMove(false);
            }
        }

        public void OnMouseLook(InputAction.CallbackContext context)
        {
            Vector2 lookVector = Vector2.zero;
            if (context.performed && !_playerController.Inventory.IsInventoryOpen && GameManager.GetInstance().IsInitialized)
            {
                lookVector = context.ReadValue<Vector2>();
                _playerController.MouseLook.SetCanLook(true);
                _playerController.MouseLook.OnLook(lookVector);
            }
            if (context.canceled)
            {
                _playerController.MouseLook.SetCanLook(false);
            }
            
        }

        #endregion
    }
}