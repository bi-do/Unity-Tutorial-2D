using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private KnightController_Joystick knight_controller;

    [SerializeField] private GameObject background_UI;
    [SerializeField] private GameObject handler_UI;

   

    private Vector2 start_pos, cur_pos;

    

    void Start()
    {
        this.background_UI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.start_pos = eventData.position;
        this.background_UI.transform.position = start_pos;
        background_UI.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.cur_pos = eventData.position;
        Vector2 drag_dir = cur_pos - start_pos;

        float max_dist = Mathf.Min(drag_dir.magnitude, 100f);

        this.handler_UI.transform.position = this.start_pos + drag_dir.normalized * max_dist;
        knight_controller.InputJoystick(drag_dir.x, drag_dir.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knight_controller.InputJoystick(0, 0);
        handler_UI.transform.localPosition = Vector2.zero;
        background_UI.SetActive(false);
    }


}
