using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public static Generation instance;
    public int num = 0;
    int random;
    public GameObject[] construction_items = new GameObject[3];
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
        while(num < 3)
        {
            random = Random.Range(0, 2);
            num++;
            Instantiate(construction_items[random],new Vector3 ((-2*num)-1,-3,-1), Quaternion.identity);
        }

    }

    // Update is called once per frame
    public void CreateObject(Vector3 pos)
    {
        random = Random.Range(0, 2);
        Instantiate(construction_items[random], pos, Quaternion.identity);
    }
}
