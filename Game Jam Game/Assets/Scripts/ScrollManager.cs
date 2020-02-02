using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollManager : MonoBehaviour
{
    public bool flipped;
    public float speed = 5;
    Transform trans_rights;

    // Start is called before the first frame update
    void Start()
    {
        trans_rights = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && (this.transform.position.y > 0))
        {
            trans_rights.position = new Vector3(trans_rights.position.x, trans_rights.position.y - .1f, trans_rights.position.z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            trans_rights.transform.position = new Vector3(trans_rights.position.x, trans_rights.position.y + .1f, trans_rights.position.z);
        }
        /*
        idk wtf you were doing here
        if (clicked)
        {
            if (flipped)
            {
                //scroll down
                camera.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - .1f, Camera.main.transform.position.z);
            }
            else
            {
                //scroll up
                camera.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + .1f, Camera.main.transform.position.z);
            }
        }
        */
    }
}
