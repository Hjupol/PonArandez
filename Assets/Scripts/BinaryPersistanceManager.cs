using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class BinaryPersistanceManager : MonoBehaviour
{
    public static int[] totalCoins;
    public static int[] maxCoins;

    private void Awake()
    {
        totalCoins = new int[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < totalCoins.Length; i++)
        {
            totalCoins[i] = 0;
        }
        //Debug.Log(SceneManager.sceneCount.ToString());
        maxCoins = LoadScore();
    }

    public static void ResetScore()
    {
        for (int i = 0; i < totalCoins.Length; i++)
        {
            totalCoins[i] = 0;
        }
    }
    public static void SaveScore(int score)
    {
        int actualScene = SceneManager.GetActiveScene().buildIndex;

        if (score > maxCoins[actualScene])
        {
            maxCoins[actualScene] = score;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/playersave.sav", FileMode.Create);
            MaxScore data = new MaxScore(score);
            bf.Serialize(stream, data);
            stream.Close();
        }
        score = 0;
    }

    public static int[] LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/playersave.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/playersave.sav", FileMode.Open);
            MaxScore data = bf.Deserialize(stream) as MaxScore;
            stream.Close();
            return data._data;
        }
        else
        {
            FileStream stream = new FileStream(Application.persistentDataPath + "/playersave.sav", FileMode.Create);
            return new int[SceneManager.sceneCount];
        }
    }
}

[Serializable]
public class MaxScore
{
    public int[] _data;

    public MaxScore(int points)
    {
        Debug.Log(points);
        
        if (_data[SceneManager.GetActiveScene().buildIndex] < points)
        {
            _data[SceneManager.GetActiveScene().buildIndex] = points;
        }
    }
}
