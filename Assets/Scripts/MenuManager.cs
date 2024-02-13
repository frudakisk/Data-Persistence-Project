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

    //Called before any Start() methods
    private void Awake()
    {
        if(Instance != null) //if statement to stop duplicate MenuManagers
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    /// <summary>
    /// Save our info into our SaveData class and turn that class into JSON.
    /// save JSON file in special path
    /// </summary>
    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.username = username;
        data.highscore = highscore;
        data.highscoreHolder = highscoreHolder;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    /// <summary>
    /// Call up the data we may have saved at our special path
    /// and assign saved values to our current MenuManger instance
    /// </summary>
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

    /// <summary>
    /// A serializable class ready for json format conversion
    /// </summary>
    [System.Serializable]
    class SaveData
    {
        public string username;
        public int highscore;
        public string highscoreHolder;
    }

}
