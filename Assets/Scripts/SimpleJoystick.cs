using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform handle;
    public float horizontal;
    public float vertical;

    private Vector2 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontal = 0f;
        vertical = 0f;
        startPosition = handle.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragPosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,   // joystick image backgrond
            eventData.position,           // handle position
            eventData.pressEventCamera,   // camera
            out dragPosition              // output
        );

        // Max 100
        dragPosition = Vector2.ClampMagnitude(dragPosition, 100);

        // Update handle image inside Joystick image
        handle.anchoredPosition = dragPosition;

        // Update these values for using in car code
        horizontal = dragPosition.x / 100f;
        vertical = dragPosition.y / 100f;
    }

    // Needed for timer to reset handle
    public void ResetJoystick(){
        handle.anchoredPosition = startPosition;

        horizontal = 0f;
        vertical = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Move handle back to center
        handle.anchoredPosition = startPosition;

        // Reset input values
        horizontal = 0f;
        vertical = 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // No code but need it for not showing error
    }
}
