using UnityEngine;

public class MouseObjectEvent : MonoBehaviour
{
    void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
    }

    void OnMouseDrag()
    {
        Debug.Log("Mouse Drag");
    }

    void OnMouseUp()
    {
        Debug.Log("Mouse up");
    }
}
