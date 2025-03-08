using UnityEngine;

public class Item : MonoBehaviour
{
    #region non public fields
    
    [SerializeField] 
    private Sprite _sprite;
    [SerializeField] 
    private SpriteRenderer _spriteRenderer;
    [SerializeField] 
    private ItemType _itemType;
    
    #endregion

    #region public fields

    public Sprite Sprite => _sprite;
    public ItemType ItemPositionType => _itemType;
    
    #endregion

    #region non public methods

    #endregion

    #region public methods

    #endregion
}
