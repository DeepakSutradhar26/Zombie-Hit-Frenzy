using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform joystickBackground;
    public RectTransform joystickHandle;

    Vector2 joystickStartPosition;

    void Start()
    {
        joystickStartPosition = joystickBackground.position;
    }

    // This code is for passing drag event to joystick
    public void OnDrag(PointerEventData eventData)
    {
        ExecuteEvents.Execute(
            joystickBackground.gameObject,
            eventData,
            ExecuteEvents.dragHandler
        );
    }

    // If someone puts the finger in the lower region of screen, the joystick dragging will start from their
    public void OnPointerDown(PointerEventData eventData)
    {
        joystickBackground.position = eventData.position;
    }

    // If someone moved their finger up, the joystick position will set to its initial position
    // And to update car speed to zero, we will also call pointer up of joystickBackground
    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBackground.position = joystickStartPosition;

        ExecuteEvents.Execute(
            joystickBackground.gameObject,
            eventData,
            ExecuteEvents.pointerUpHandler
        );
    }
}