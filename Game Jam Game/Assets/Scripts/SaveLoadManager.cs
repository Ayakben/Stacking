using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;
    public Data data;
    string datafile = "save.sav";
    // Update is called once per frame
    private void Start()
    {
    }
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    public void Save()
    {
        string filePath = Application.persistentDataPath + "/" + datafile;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        string filePath = Application.persistentDataPath + "/" + datafile;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            FileStream file = File.Open(filePath, FileMode.Open);
            Data loaded = (Data)bf.Deserialize(file);
            data = loaded;
            file.Close();
        }
        // sort the loaded data just in case because I'm not sure it's saved in a sorted way
        //more of a safety measure
        Sort();
    }
    public void Sort()
    {
        int temp;
        for (int j = 0; j <= data.score.Length - 2; j++)
        {
            for (int i = 0; i <= data.score.Length - 2; i++)
            {
                if (data.score[i] < data.score[i + 1])
                {
                    temp = data.score[i + 1];
                    data.score[i + 1] = data.score[i];
                    data.score[i] = temp;
                }
            }
        }
    }
[System.Serializable]
public class Data
{
        public int[] score = new int[10];
}
}