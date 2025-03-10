using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        #region non public fields

        [SerializeField]
        private Renderer _renderer;
        [SerializeField]
        private float _timeBetweenColorChange = .2f;
        [SerializeField]
        private Color _hitColor;

        private Color _cachedMaterialColor;
        private bool _shouldChangeColor;
        private float _timer = 0f;
    
        #endregion

        #region public fields

    
        #endregion

        #region non public methods
        private void Awake()
        {
            _cachedMaterialColor = _renderer.material.GetColor("_Color");
        }

        private void Update()
        {
            if (!_shouldChangeColor)
            {
                return;
            }
            _timer += Time.deltaTime;
            if (_timer >= _timeBetweenColorChange)
            {
                _renderer.material.color = _cachedMaterialColor;
                _shouldChangeColor = false;
            }
        }

        #endregion

        #region public methods
    
        public void ChangeObjectColor()
        {
            _shouldChangeColor = true;
            _timer = 0f;
            _renderer.material.color = _hitColor;
        }

        #endregion
    }
}