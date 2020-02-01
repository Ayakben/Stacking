using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragUI : MonoBehaviour
{
    Rigidbody2D shape;
    private bool clicked = false;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }
    }
    private void Start()
    {
        //Sets variable shape to the current objects rigidbody to change gravity
        shape = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (clicked == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
            shape.gravityScale = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
            shape.gravityScale = 1;
        }
    }
}