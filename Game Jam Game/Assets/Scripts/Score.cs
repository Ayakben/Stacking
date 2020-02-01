using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int score;
    public static void SetScore(int value)
    {
        score = value;
    }
    public static int GetScore()
    {
        return score;
    }
}
