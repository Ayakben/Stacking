using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public static Generation instance;
    public int num = 0;
    int random;
    //array of all prefabs for possible items
    public GameObject[] construction_items = new GameObject[11];
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        //generate random number 3 times
        //use each number to select a random item at 3 starting locations
        while(num < 3)
        {
            random = Random.Range(0, 10);
            num++;
            Instantiate(construction_items[random],new Vector3 ((-2*num)-1,Camera.main.transform.position.y-2.5f,-1), Quaternion.identity);
        }

    }

    // Create random object at specific position
    public void CreateObject(Vector3 pos)
    {
        random = Random.Range(0, 10);
        Instantiate(construction_items[random], pos, Quaternion.identity);
    }
}
