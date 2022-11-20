using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool Pressed;
    private Image _backPanel;
    private Image _knob;

    public Vector3 InputDirection;

    private void Start()
    {
        _backPanel = GetComponent<Image>();
        _knob = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData pointerEventData)
    {
        Vector2 position;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (_backPanel.rectTransform,
                pointerEventData.position,
                pointerEventData.pressEventCamera,
                out position))
        {
            // Get the touch position
            Vector2 sizeDelta = _backPanel.rectTransform.sizeDelta;
            position.x = (position.x / sizeDelta.x);
            position.y = (position.y / sizeDelta.y);

            // Calculate the move position
            float x = (_backPanel.rectTransform.pivot.x == 1) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (_backPanel.rectTransform.pivot.y == 1) ? position.y * 2 + 1 : position.y * 2 - 1;

            // Input position
            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            // Move the knob
            Vector2 delta = _backPanel.rectTransform.sizeDelta;
            _knob.rectTransform.anchoredPosition =
                new Vector3(InputDirection.x * (delta.x / 3),
                    InputDirection.z * (delta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData pointerEventData)
    {
        OnDrag(pointerEventData);
        Pressed = true;
    }

    public virtual void OnPointerUp(PointerEventData pointerEventData)
    {
        InputDirection = Vector3.zero;
        _knob.rectTransform.anchoredPosition = Vector3.zero;
        Pressed = false;
    }
}