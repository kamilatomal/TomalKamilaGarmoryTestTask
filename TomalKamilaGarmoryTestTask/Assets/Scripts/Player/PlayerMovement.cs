using Main;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region non public fields

        [SerializeField] 
        private float _basicMoveSpeed;
        [SerializeField] 
        private Rigidbody _myRigidbody;

        private Vector2 _movementDirection;
        private bool _shouldMove;
        
        #endregion

        #region public fields

        public bool IsMoving => _shouldMove;

        #endregion

        #region non public methods
        
        private void FixedUpdate()
        {
            if (_shouldMove)
            {
                Move();
            }
        }
        
        private void Move()
        {
            Vector2 velocity = _myRigidbody.linearVelocity;
            float finalMoveSpeed = _basicMoveSpeed + (_basicMoveSpeed * GameManager.GetInstance().PlayerData.GetMovementMultiplier());
            velocity.x = _movementDirection.x * finalMoveSpeed;
            _myRigidbody.linearVelocity = velocity;
        }

        private void ResetMoveData()
        {
            _shouldMove = false;
            Vector2 velocity = _myRigidbody.linearVelocity;
            velocity.x = 0;
            _myRigidbody.linearVelocity = velocity;
        }
        
        
        #endregion

        #region public methods
        
        public void OnWalk(Vector2 movementDirection)
        {
            if (movementDirection.sqrMagnitude > Mathf.Epsilon)
            {
                _movementDirection = movementDirection;
                _shouldMove = true;
            }
            else
            {
                ResetMoveData();
            }
        }

        #endregion
    }
}