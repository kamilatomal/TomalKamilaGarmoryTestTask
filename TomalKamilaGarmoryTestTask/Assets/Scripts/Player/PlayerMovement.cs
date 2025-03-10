using Main;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region non public fields

        [SerializeField] private float _basicMoveSpeed;
        [SerializeField] private Rigidbody _myRigidbody;

        private Vector3 _movementVector;
        private bool _canMove;

        #endregion

        #region public fields

        public bool CanMove => _canMove;

        #endregion

        #region non public methods

        private void FixedUpdate()
        {
            if (!_canMove)
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            float finalMoveSpeed = _basicMoveSpeed +
                                   (_basicMoveSpeed * GameManager.GetInstance().PlayerData.GetMovementMultiplier());

            Vector3 movementDirection =
                ((transform.forward * _movementVector.y) + (transform.right * _movementVector.x)).normalized;
            _myRigidbody.MovePosition(_myRigidbody.position +
                                      (movementDirection * (finalMoveSpeed * Time.fixedDeltaTime)));
        }

        private void ResetMoveData()
        {
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
                _movementVector = movementDirection;
            }
            else
            {
                ResetMoveData();
            }
        }

        public void SetCanMove(bool canMove)
        {
            _canMove = canMove;
        }

        #endregion
    }
}