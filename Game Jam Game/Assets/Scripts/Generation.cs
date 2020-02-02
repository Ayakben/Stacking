using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int num = 0;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        if(num < 2)
        {
            num++;
            GameObject newGameObject = Instantiate(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
