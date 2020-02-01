using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public string text;
    public GameObject textBox;
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
        text = (GetScore() * 100).ToString();
        textBox.GetComponent<Text>().text = text;
    }
}
