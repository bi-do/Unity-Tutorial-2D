using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Update()
    {
        MouseClickEvent();
    }

    private void MouseClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Btn down.");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Btn ing...");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Btn up.");
        }
    }
}
