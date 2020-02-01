using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragUI : MonoBehaviour
{
    private bool clicked = false;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }
    }

    void Update()
    {
        if (clicked == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }
    }
}