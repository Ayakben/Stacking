using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text scores;
    string s = "";
    int count = 1;
    void Awake()
    {
        scores.text = s;
       foreach(int score in SaveLoadManager.instance.data.score)
        {
            s = score.ToString();
            scores.text += count.ToString() + ". " + s + "\n";
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
