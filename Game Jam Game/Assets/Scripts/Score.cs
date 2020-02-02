using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text score_text;
    public float score;
    public GameObject scorer;
    public int score_int = 0;
    public float score_max;
    public float count = 0;

    public float getScore()
    {
        return score;
    }
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
        if (scorer != null)
        {
            //account for starting height of foundation
            //determine score from height of scorer gameobject
            score = scorer.transform.position.y + 2.684f;
            //set the tag for the specific gameobject
            //this object will be the object at the highest point
            //this should be the object above the mark when it's dropped
            scorer.tag = "Set";
            score_int = (int)(score * 500);
            score_text.text = (score_int).ToString();
        }
            if(scorer.tag == "Set")
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
        }
