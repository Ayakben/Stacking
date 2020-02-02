using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text score_text;
    public float score = 0;
    public GameObject scorer;
    public int score_int = 0;
    public float score_max= 7500;
    public float count = 0;
    public Transform DropArea;
    public bool victory= false;
    public bool loss = false;
    public GameObject win;
    public GameObject lose;
    public GameObject cont;
    public GameObject cutscene;

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
    void Update()
    {
        lose.SetActive(loss);
            win.SetActive(victory);
        if (victory && Cutscene.instance.all)
        {
            cont.SetActive(victory);
        }
        if (!loss && !victory)
        {
            if (scorer != null)
            {
                //account for starting height of foundation
                //determine score from height of scorer gameobject
                score = scorer.transform.position.y + 3.529528f;
                //set the tag for the specific gameobject
                //this object will be the object at the highest point
                //this should be the object above the mark when it's dropped
                scorer.tag = "Set";
                score_int = (int)(score * 500);
                score_text.text = "SCORE: " + (score_int).ToString();
                if (scorer.tag == "Set")
                {
                    if (count < 1000)
                    {
                        if (score_int >= score_max)
                        {
                            count += 1;
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
            }
            if (DropArea.position.y < score) DropArea.Translate(0, .01f, 0);
            if (DropArea.position.y > score) DropArea.Translate(0, -.01f, 0);
        }
        if(count >= 1000)
        {
            if (score_int >= score_max)
            {
                victory = true;
                    cutscene.SetActive(victory);
                    Cutscene.instance.done = true;
                count = 0;
            }
        }
    }
        }
