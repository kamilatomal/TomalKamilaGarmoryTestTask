using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "RarityConfig", menuName = "Item/RarityConfig")]
    public class RarityConfig : ScriptableObject
    {
        #region non public fields

        [SerializeField]
        private List<RarityWithSprite> _rarityWithSprite;

        #endregion

        #region public fields


        #endregion

        #region non public methods


        #endregion

        #region public methods


        #endregion

    }
}