using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class GetArchiverment : MonoBehaviour
{
    private string ACHIEVEMENT_API_PATH = "http://localhost:3000/api/my-achievement/";
    private string userID;

    //private string filepath = "ProGame.json";

    private string filepath = Path.Combine(Application.streamingAssetsPath, "Achievement.json");

    private string path = "word";
    private string Encry(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] + path[i % path.Length]);
        }
        return modifiedData;
    }
    private string Encry_(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] - path[i % path.Length]);
        }
        return modifiedData;
    }

    public static GetArchiverment Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        RefreshJson();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RefreshJson()
    {
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, "");
        }
    }
    public void GetData()
    {
        StartCoroutine(GetAchievement());
    }


    public IEnumerator GetAchievement()
    {
        userID = PlayerPrefs.GetString("UserID");

        using (UnityWebRequest www = UnityWebRequest.Get($"{ACHIEVEMENT_API_PATH}{userID}"))
        {
            yield return www.SendWebRequest();
            _Achievement open = JsonUtility.FromJson<_Achievement>(www.downloadHandler.text);
            SaveAchievement(open);
            Debug.Log(open.open[0].name + ">>>>>>>>>>>>>>>>>");
        }

    }
    
    public void SaveAchievement(_Achievement _data)
    {
        string datanew = JsonConvert.SerializeObject(_data);

        string dataSvae = Encry(datanew);
        Debug.Log(dataSvae + " :data SaveAchievement");

        string dataTest = Encry_(dataSvae);
        Debug.Log(dataTest + " :data SaveAchievement test");

        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, dataSvae);
        }

    }

    [System.Serializable]

    public class _Achievement
    {
        public open[] open;
    }
    [System.Serializable]
    public class open {
   
        public string id;
        public string name;
        public int countNow;
        public countFinish countFinish;
        public reward reward;
        public int finishNumber;
        public string user_id;
    }

    [System.Serializable]
    public class countFinish
    {
        public int m1;
        public int m2;
        public int m3;
    }

    [System.Serializable]
    public class reward
    {
        public int m1;
        public int m2;
        public int m3;
    }
}
