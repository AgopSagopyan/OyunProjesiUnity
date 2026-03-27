using UnityEngine;

public class ShopControls : MonoBehaviour
{
    public GameObject shopUi;


    public void CloseShop()
    {
        shopUi.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }
}
