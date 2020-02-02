using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragUI : MonoBehaviour
{
    Rigidbody2D shape;
    public bool clicked = false;
    PolygonCollider2D poly;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && shape.gameObject.tag != "Set")
        {
            clicked = true;
            shape.freezeRotation = true;
        }
    }
    private void Start()
    {
        //Sets variable shape to the current objects rigidbody to change gravity
        shape = GetComponent<Rigidbody2D>();
        poly = GetComponent<PolygonCollider2D>();
    }
    void Update()
    {
        if (clicked == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shape.MovePosition(cursorPos);
            shape.gravityScale = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
            if (poly.isTrigger == false)
            {
                shape.freezeRotation = false;
                shape.gravityScale = 1;
            }
        }
    }
}