using Main;
using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private ProjectileConfig _projectileConfig;
        [SerializeField]
        private Transform _projectileSpawnPoint;
        [SerializeField]
        private LayerMask _layerMask;

        private Projectile _createdProjectile;


        public void OnShoot(Vector3 targetPosition)
        {
            Vector3 aimDirection = (targetPosition - _projectileSpawnPoint.transform.position).normalized;
            _createdProjectile = PoolManager.Instance.GetProjectile();
            _createdProjectile.Setup(_projectileConfig);
            _createdProjectile.transform.position = _projectileSpawnPoint.transform.position;
            _createdProjectile.transform.rotation = Quaternion.LookRotation(aimDirection, Vector3.up);
        }

        public Vector3 GetShootTargetPosition()
        {
            Vector3 mouseWorldPosition = Vector3.zero;
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        
                if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _layerMask))
                {
                    mouseWorldPosition = raycastHit.point;
                }
                else
                {
                    return ray.GetPoint(100);
                }
            }

            return mouseWorldPosition;
        }
    }
}