using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnScreenButtonVisuals : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Image buttonImage;

    [Tooltip("The normal look of the button.")]
    public Sprite normalSprite;

    [Tooltip("The look of the button when pressed.")]
    public Sprite pressedSprite;

    void Start()
    {
        // Automatically find the Image component on this object
        buttonImage = GetComponent<Image>();
        
        if (normalSprite == null && buttonImage != null)
        {
            normalSprite = buttonImage.sprite;
        }
    }

    // Runs the moment a finger touches the image
    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonImage != null && pressedSprite != null)
        {
            buttonImage.sprite = pressedSprite;
        }
    }

    // Runs the moment the finger lifts off the image
    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonImage != null && normalSprite != null)
        {
            buttonImage.sprite = normalSprite;
        }
    }
}