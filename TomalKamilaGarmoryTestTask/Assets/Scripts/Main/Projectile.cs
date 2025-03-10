using UnityEngine;

namespace Main
{
    public class Projectile : MonoBehaviour
    {
        #region non public fields

        private ProjectileConfig _projectileConfig;
        private float _timer = 0;
    
        #endregion

        #region public fields

    
        #endregion

        #region non public methods
        private void FixedUpdate()
        {
            if (!_projectileConfig)
            {
                return;
            }
            MoveProjectile();
            _timer += Time.fixedDeltaTime;
            if (_timer >= _projectileConfig.DestroyAfterSeconds)
            {
                PoolManager.Instance.ReturnProjectileBackToPool(this);
                _timer = 0;
            }
        }

        private void MoveProjectile()
        {
            transform.position += (transform.forward * (_projectileConfig.ProjectileSpeed * Time.fixedDeltaTime));
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HealthController healthController))
            {
                healthController.DealDamage(_projectileConfig.Damage);

                PoolManager.Instance.ReturnProjectileBackToPool(this);
            }   
        }

        #endregion

        #region public methods
    
        public void Setup(ProjectileConfig projectileConfig)
        {
            _projectileConfig = projectileConfig;
        }

        #endregion
    }
}