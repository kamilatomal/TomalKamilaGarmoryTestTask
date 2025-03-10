using UnityEngine;

namespace Main
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Projectile/Projectile Config", order = 0)]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField]
        private float _damage;
        [SerializeField]
        private float _destroyAfterSeconds = 5f;
        [SerializeField]
        private float _projectileSpeed = 5f;

        public float Damage => _damage;
        public float DestroyAfterSeconds => _destroyAfterSeconds;
        public float ProjectileSpeed => _projectileSpeed;
    }
}