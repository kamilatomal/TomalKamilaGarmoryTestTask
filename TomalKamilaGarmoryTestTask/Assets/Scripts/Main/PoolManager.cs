using UnityEngine;
using UnityEngine.Pool;

namespace Main
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField]
        private Transform _projectilesContainer;
        [SerializeField]
        private Projectile _projectilePrefab;
        [SerializeField]
        private int _defaultCapacity = 100;
        [SerializeField]
        private int _maxCapacity = 300;

        private ObjectPool<Projectile> _projectilePool;
        
        public static PoolManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            _projectilePool = new ObjectPool<Projectile>(CreateProjectile, (Projectile projectile) =>
            {
                projectile.gameObject.SetActive(true);
            }, (Projectile projectile) =>
            {
                projectile.gameObject.SetActive(false);
            }, (Projectile projectile) =>
            {
                Destroy(projectile.gameObject);
            }, false, _defaultCapacity, _maxCapacity);
        }

        private Projectile CreateProjectile()
        {
            Projectile projectile = Instantiate(_projectilePrefab);
            projectile.transform.SetParent(_projectilesContainer);
            return projectile;
        }

        public Projectile GetProjectile()
        {
            Projectile projectile = _projectilePool.Get();
            return projectile;
        }

        public void ReturnProjectileBackToPool(Projectile projectile)
        {
            _projectilePool.Release(projectile);
            projectile.transform.SetParent(_projectilesContainer);
        }
    }
}