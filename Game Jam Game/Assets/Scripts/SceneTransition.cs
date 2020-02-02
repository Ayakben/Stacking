using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //We can put all of our menu music in the array so we can stop it all at a given time to play the next menu music
    public AudioSource menuMusic;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playAudio(AudioSource audio)
    {
        audio.Play(0);
    }
    public void SceneChange_0()
    {
        //make sure that we're in the main game screen before saving a score to avoid errors
        if (Score.instance != null)
        {
            //change leaderboard values
            //from bottom to top, swap out lowest value that is less than current score
            //assuming an ordered list, this makes the insertion very quick
            for (int i = 9; i > -1; i--)
            {
                if (Score.instance.score_int > SaveLoadManager.instance.data.score[i])
                {
                    SaveLoadManager.instance.data.score[i] = Score.instance.score_int;
                    break;
                }
            }
            int temp;
            
            //orders the list of values
            //descending order
            //a bit more costly than other potential sorts, but simple and negligible cost for small list size
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

        }   
        //save the score values to be displayed
        SaveLoadManager.instance.Save();
        /*
        for (int i = 0; i < menuMusic.Length; i++)
        {
            menuMusic[i].Stop();
        }
        */
        menuMusic.Play(0);
        SceneManager.LoadScene(0);
    }
    public void SceneChange_1()
    {
        //stops all other menu music
        /*
        for(int i = 0; i < menuMusic.Length; i++)
        {
            menuMusic[i].Stop();
        }
        */
        SceneManager.LoadScene(1);
        menuMusic.Play(0);
    }
    public void SceneChange_2()
    {
        //load the save data when we go to the leaderboard screen
        SaveLoadManager.instance.Load();
        SceneManager.LoadScene(2);
        /*
        for (int i = 0; i < menuMusic.Length; i++)
        {
            menuMusic[i].Stop();
        }
        */
        menuMusic.Play(0);
    }
    public void SceneChange_3()
    {
        Application.Quit();
    }
}
