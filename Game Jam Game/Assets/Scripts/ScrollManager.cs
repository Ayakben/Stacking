using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollManager : MonoBehaviour
{
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
    }
}
