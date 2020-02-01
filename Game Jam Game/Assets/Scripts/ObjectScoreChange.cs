using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScoreChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Sets score to the y position of the object
        int pos = (int) transform.position.y;
        Score.SetScore(pos);
    }
}
