using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Items
{
    public class DraggableGameObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region non public fields

        [SerializeField] 
        private Image _image;
        [SerializeField] 
        private Transform _parentWhileDragging;

        private Transform _originParent;
        private Func<PointerEventData, bool> _onDragEnd;

        #endregion

        #region public fields

        #endregion

        #region non public methods

        #endregion

        #region public methods

        public void Setup(Func<PointerEventData, bool> onDragEnd)
        {
            _onDragEnd = onDragEnd;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _originParent = transform.parent;
            transform.SetParent(_parentWhileDragging);
            _image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(_originParent);
            _image.raycastTarget = true;
            _onDragEnd?.Invoke(eventData);
        }

        #endregion
    }
}