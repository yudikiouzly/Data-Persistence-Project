using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string PlayerName;
    public string BestPlayer;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadRecord();
    }


    [System.Serializable]
    class History
    {
        public string name;
        public int score;
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            History record = JsonUtility.FromJson<History>(json);

            BestPlayer = record.name;
            BestScore = record.score;
        }
    }

    public void SaveRecord(string name, int score)
    {
        History record = new History();
        record.name = name;
        record.score = score;

        string json = JsonUtility.ToJson(record);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SaveRecord()
    {
        History record = new History();
        record.name = BestPlayer;
        record.score = BestScore;

        string json = JsonUtility.ToJson(record);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
