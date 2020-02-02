using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour
{
   public float move_height;
    // Start is called before the first frame update
    void Start()
    {
        SetMark();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y + 2.5f < this.transform.position.y) this.enabled = false;
        else
        {
            this.enabled = true;
        }
        if(Score.instance.score > move_height)
        {
            SetMark();
        }

    }
    void SetMark()
    {
        this.transform.position = new Vector3(this.transform.position.x, Score.instance.score, this.transform.position.z);
        move_height = Score.instance.score;
    }
}
