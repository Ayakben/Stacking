using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollManager : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public bool flipped;
    public Camera camera;
    public bool clicked;
    public void OnPointerDown(PointerEventData eventData)
    {
        clicked = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        clicked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            if (flipped)
            {
                camera.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - .1f, Camera.main.transform.position.z);
            }
            else
            {
                camera.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + .1f, Camera.main.transform.position.z);
            }
        }
        if(camera.transform.position.y-2.684 < Score.instance.scorer.transform.position.y)StartCoroutine(MoveUp());
        //StartCoroutine(MoveDown());
    }
    public IEnumerator MoveUp()
    {
        Debug.Log("Stuff");
        yield return 0;
    }
    public IEnumerator MoveDown()
    {

        yield return 0;
    }
}
