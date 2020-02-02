using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    //sprites for the buttons
    public Sprite o1;
    public Sprite o2;
        public Sprite o3;
        public Sprite o4;
        public Sprite o5;
        public Sprite o6;
    public Button but;
    public int num = 3;
    public static Cutscene instance;
    public bool done = true;
    public bool all = false;
    //change the sprites for the button
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
    public void ChangeImage()
    {
        switch (num)
        {
            case 0:
                num++;
                but.image.sprite = o4;
                break;
            case 1:
                num++;
                but.image.sprite = o5;
                break;
            case 2:
                num++;
                but.image.sprite = o6;
                break;
            case 3:
                num++;
                but.image.sprite = o1;
                break;
            case 4:
                num++;
                but.image.sprite = o2;
                break;
            case 5:
                num++;
                but.image.sprite = o3;
                break;
            case 6:
                done = false;
                if (Score.instance.victory) all = true;
                num = 0;
                break;

        }
    }
    public void Update()
    {
        this.gameObject.SetActive(done);
    }
}
