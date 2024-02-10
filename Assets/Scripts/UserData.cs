using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserData : MonoBehaviour
{
    public static UserData Instance;
    public string PlayerName;
    public int bestScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    public void SavePlayerData()
    {
        SaveData saveData = new SaveData();
        saveData.Name = UserData.Instance.PlayerName;
        saveData.Score = UserData.Instance.bestScore;
        string json = JsonUtility.ToJson(saveData);
        //File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        File.WriteAllText("D:/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        //string path = Application.persistentDataPath + "/savefile.json";
        string path = "D:/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData loadData = JsonUtility.FromJson<SaveData>(json);
            UserData.Instance.PlayerName = loadData.Name;
            UserData.Instance.bestScore = loadData.Score;
        }
        
    }
}
