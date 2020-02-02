using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragUI : MonoBehaviour
{
    Rigidbody2D shape;
    public bool clicked = false;
    PolygonCollider2D poly;
    public Vector3 pos;
    void OnMouseOver()
    {
        //Set is a tag that indicates whether or not a block has been dropped
        //blocks that have that tag have been dropped and can no longer be picked
        //refer to the Score script for where it's set

        //check for the Set tag
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
        pos = shape.gameObject.transform.position;
    }
    void Update()
    {
        if (!Score.instance.loss && !Score.instance.victory)
        {
            if (clicked == true)
            {
                Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                shape.MovePosition(cursorPos);
                shape.gravityScale = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                pos.z += 1;
                clicked = false;
                if (poly.isTrigger == false)
                {
                    shape.freezeRotation = false;
                    shape.gravityScale = 1;
                }
            }
        }
    }
}