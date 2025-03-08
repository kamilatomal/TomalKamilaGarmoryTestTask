using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Item/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;
}
