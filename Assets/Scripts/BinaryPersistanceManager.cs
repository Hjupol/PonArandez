using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinaryPersistanceManager : MonoBehaviour
{
    public static int totalCoins = 0;
    public static int maxCoins;

    private void Awake()
    {
        maxCoins = LoadScore();
    }

    public static void ResetScore()
    {
        totalCoins = 0;
    }
    public static void SaveScore(int score)
    {
        if (score > maxCoins)
        {
            maxCoins = score;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/playersave.sav", FileMode.Create);
            MaxScore data = new MaxScore(score);
            bf.Serialize(stream, data);
            stream.Close();
        }
        score = 0;
    }

    public static int LoadScore()
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
            return new int();
        }
    }
}

[Serializable]
public class MaxScore
{
    public int _data;

    public MaxScore(int points)
    {
        Debug.Log(points);
        if (_data < points)
        {
            _data = points;
        }
    }
}
