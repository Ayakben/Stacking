using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneChange_0()
    {
        if (Score.instance != null)
        {
            for (int i = 9; i > -1; i--)
            {
                if (Score.instance.score_int > SaveLoadManager.instance.data.score[i])
                {
                    SaveLoadManager.instance.data.score[i] = Score.instance.score_int;
                    break;
                }
            }
            int temp;

            for (int j = 0; j <= SaveLoadManager.instance.data.score.Length - 2; j++)
            {
                for (int i = 0; i <= SaveLoadManager.instance.data.score.Length - 2; i++)
                {
                    if (SaveLoadManager.instance.data.score[i] < SaveLoadManager.instance.data.score[i + 1])
                    {
                        temp = SaveLoadManager.instance.data.score[i + 1];
                        SaveLoadManager.instance.data.score[i + 1] = SaveLoadManager.instance.data.score[i];
                        SaveLoadManager.instance.data.score[i] = temp;
                    }
                }
            }

        }        SaveLoadManager.instance.Save();
        
        SceneManager.LoadScene(0);
    }
    public void SceneChange_1()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneChange_2()
    {
        SaveLoadManager.instance.Load();
        SceneManager.LoadScene(2);
    }
    public void SceneChange_3()
    {
        Application.Quit();
    }
}
