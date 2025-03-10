using UnityEngine;

namespace Player
{
    public class MouseLook : MonoBehaviour
    {
        #region non public fields

        [SerializeField] 
        private Transform _playerBody;
        [SerializeField] 
        private float _mouseSensitivity = 100f;
        [SerializeField]
        private float _upDownRange = 70f;

        private Vector2 _mouseLookVector;
        private bool _canLook;
        private float _verticalRotation;

        #endregion

        #region public fields
        

        #endregion

        #region non public methods

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        private void Update()
        {
            if (!_canLook)
            {
                return;
            }

            float mouseX = _mouseLookVector.x * _mouseSensitivity * Time.deltaTime;
            float mouseY = _mouseLookVector.y * _mouseSensitivity * Time.deltaTime;

            _verticalRotation -= mouseY;
            _verticalRotation = Mathf.Clamp(_verticalRotation, -_upDownRange, _upDownRange);
            
            transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    
        #endregion

        #region public methods
  
        public void OnLook(Vector2 mouseLookVector)
        {
            _mouseLookVector = mouseLookVector;
        }
    
        public void SetCanLook(bool canLook)
        {
            _canLook = canLook;
        }

        #endregion
    }
}