using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScoreChange : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    public bool sleep;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(rigidbody.IsSleeping())
        {
            sleep = true;
        }
        else
        {
            sleep = false;
        }
        speed = rigidbody.velocity.magnitude;
        //Sets score to the y position of the object
        int pos = (int) transform.position.y;
        if (pos > Score.GetScore())
        {
            if (!(Input.GetMouseButton(0)))
            {
                if (rigidbody.IsSleeping())
                {
                    Score.SetScore(pos);
                }
            }
        }
    }
}
