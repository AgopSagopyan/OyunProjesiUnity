using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCameraAxisProvider : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Sensitivity")]
    public float sensitivityX = 0.1f;
    public float sensitivityY = 0.1f;

    // Cinemachine v3 reads these properties directly
    public float TouchX { get; private set; }
    public float TouchY { get; private set; }

    private bool _isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragging)
        {
            // Set the touch values to the frame-by-frame drag distance
            TouchX = eventData.delta.x * sensitivityX;
            TouchY = eventData.delta.y * sensitivityY;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
        ResetInputs();
    }

    void Update()
    {
        // If the user stops moving their finger but leaves it on the screen, 
        // eventData.delta stops updating, so we must clear it here.
        if (!_isDragging)
        {
            ResetInputs();
        }
    }

    void LateUpdate()
    {
        // Clear inputs at the end of the frame so it acts like a mouse delta
        if (_isDragging)
        {
            ResetInputs();
        }
    }

    private void ResetInputs()
    {
        TouchX = 0f;
        TouchY = 0f;
    }
}