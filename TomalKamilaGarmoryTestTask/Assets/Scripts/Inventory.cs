using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region non public fields

    #endregion

    #region public fields

    #endregion

    #region non public methods

    #endregion

    #region public methods

    public void SetInventoryActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    #endregion
}