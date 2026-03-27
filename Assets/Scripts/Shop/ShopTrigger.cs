using UnityEngine;
using UnityEngine.InputSystem;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopUI;

    private bool isPlayerNearby = false;

    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Interact.performed += ctx => TryOpenShop();


    }

    void OnEnable() 
    {
        controls.Enable();
    }

    void OnDisable() 
    {
        controls.Disable();
    }

    void TryOpenShop()
    {

        Debug.Log("Tried to open shop");
        if(isPlayerNearby)
        {
            ToggleShop();
        }

    }

    void ToggleShop()
    {
        bool nextState = !shopUI.activeSelf;
        shopUI.SetActive(nextState);

        Cursor.lockState = nextState ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = nextState;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Press E to Open Shop");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            shopUI.SetActive(false);
        }
    }
}
