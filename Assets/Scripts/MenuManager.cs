using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    public string username;
    public int highscore;
    public string highscoreHolder;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.username = username;
        data.highscore = highscore;
        data.highscoreHolder = highscoreHolder;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            name = data.username;
            highscore = data.highscore;
            highscoreHolder = data.highscoreHolder;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public int highscore;
        public string highscoreHolder;
    }

}
