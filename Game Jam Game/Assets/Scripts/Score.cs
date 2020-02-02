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
    public float score_max= 1000;
    public float count = 0;
    public Transform DropArea;
    public bool victory= false;
    public bool loss = false;

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
                    if (count >= 100 && score >= score_max)
                    {
                        count += .1f;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            if (DropArea.position.y < score) DropArea.Translate(0, .01f, 0);
            if (DropArea.position.y > score) DropArea.Translate(0, -.01f, 0);
            if (score == score_max)
            {
                victory = true;
            }
        }
    }
        }
