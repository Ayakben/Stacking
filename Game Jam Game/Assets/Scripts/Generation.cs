using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public Transform pos;
    public int num = 0;
    int random;
    public GameObject[] construction_items = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
       random = Random.Range(0, 2);
        if(num < 3)
        {
            num++;
            Instantiate(construction_items[random]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
