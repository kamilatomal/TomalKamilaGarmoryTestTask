using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        #region non public fields

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
                GameManager.GetInstance().PlayerComponentsContainer.Inventory.ToggleInventoryActive();
            }
        }

        #endregion
    }
}