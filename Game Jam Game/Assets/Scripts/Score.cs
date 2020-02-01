using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private static int score;
    public static void SetScore(int value)
    {
        score = value;
    }
    public static int GetScore()
    {
        return score;
    }
    void Update()
    {
        text.text = GetScore().ToString();
    }
}
