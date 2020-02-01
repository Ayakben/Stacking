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
            score = scorer.transform.position.y+ 2.684f;
            score_int = (int)(score * 500);
            score_text.text = (score_int).ToString();
        }
    }
}
