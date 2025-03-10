using UnityEngine;

namespace Main
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Projectile/Projectile Config", order = 0)]
    public class ProjectileConfig : ScriptableObject
    {
        #region non public fields

        [SerializeField]
        private float _damage;
        [SerializeField]
        private float _destroyAfterSeconds = 5f;
        [SerializeField]
        private float _projectileSpeed = 5f;
    
        #endregion

        #region public fields
        
        public float Damage => _damage;
        public float DestroyAfterSeconds => _destroyAfterSeconds;
        public float ProjectileSpeed => _projectileSpeed;
    
        #endregion

        #region non public methods

        #endregion

        #region public methods
        
        #endregion
    }
}