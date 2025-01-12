using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image joystickBackground;
    [SerializeField] private Image joystickHandle;
    private Vector2 inputVector;
    private float maxHandleDistance;

    void Start()
    {
        // Максимальное расстояние, на которое может смещаться ручка джойстика
        maxHandleDistance = joystickBackground.rectTransform.sizeDelta.x / 2;
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Определяем позицию джойстика и переводим её в координаты экрана
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground.rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out pos
        );

        // Нормализуем вектор, чтобы учитывать направление и силу
        inputVector = pos / maxHandleDistance;
        if (inputVector.magnitude > 1.0f)
            inputVector = inputVector.normalized;

        // Перемещаем ручку джойстика в зависимости от нажима
        joystickHandle.rectTransform.anchoredPosition = inputVector * maxHandleDistance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Сбрасываем позицию джойстика при отпускании
        inputVector = Vector2.zero;
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }

    public Vector2 GetInput()
    {
        return inputVector;
    }
}