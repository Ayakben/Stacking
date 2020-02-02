using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScoreChange : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public bool clicked;
    public bool scorer;
    int pos;
    // Start is called before the first frame update
    void Start()
    {
          rigidBody = GetComponent<Rigidbody2D>();
     }

    // Update is called once per frame
    void Update()
    {
        if (!Score.instance.loss && !Score.instance.victory)
        {
            clicked = rigidBody.freezeRotation;
            if (!clicked)
            {
                //based on heighest block, track the height and set it as the scorer to be used for score
                pos = (int)transform.position.y;
                if (pos > Score.instance.score)
                {
                    Score.instance.scorer = this.gameObject;
                }
                if (pos < -5)
                {
                    Score.instance.loss = true;
                    Destroy(this.gameObject);
                }
            }
        }

    }        //Sets score to the y position of the object
}
