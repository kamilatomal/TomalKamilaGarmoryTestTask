using UnityEngine;

namespace Main
{
    public class Projectile : MonoBehaviour
    {
        private ProjectileConfig _projectileConfig;
        private float _timer = 0;

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
                PoolManager.Instance.ReturnProjectileBackToPool(this);
            }   
        }

        public void Setup(ProjectileConfig projectileConfig)
        {
            _projectileConfig = projectileConfig;
        }
    }
}