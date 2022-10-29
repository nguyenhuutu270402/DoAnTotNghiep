using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonManager : MonoBehaviour
{
    //private string filepath = "ProGame.json";
    private string filepath = Path.Combine(Application.streamingAssetsPath, "ProGame.json");

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
    public static JsonManager Instance { get; private set; }

    private void Awake()
    {

        StartJson();
        Instance = this;
    }

    public void updateSounds(float value, int index)
    {
        // 0 : SFX
        // 1 : BGM
        string dataSvae = "";
        using (StreamReader r = new StreamReader(filepath))
        {
            string json = r.ReadToEnd();
            string json_ = "";
            for (int i = 1; i < json.Length - 1; i++)
            {
                json_ += json[i];
            }
            var loadData = Encry_(json_);
            ProGame game = JsonConvert.DeserializeObject<ProGame>(loadData);
            if (index == 0)
            {
                game.SFX_valu = value;
            }
            if (index == 1)
            {
                game.BGM_valu = value;
            }
            string datanew = JsonConvert.SerializeObject(game);
            dataSvae = Encry(datanew);
        }
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, dataSvae);
        }
    }

    public float[] getSounds()
    {
        float[] sound = new float[2];
        using (StreamReader r = new StreamReader(filepath))
        {
            string json = r.ReadToEnd();
            string json_ = "";
            for (int i = 1; i < json.Length - 1; i++)
            {
                json_ += json[i];
            }
            var loadData = Encry_(json_);
            ProGame game = JsonConvert.DeserializeObject<ProGame>(loadData);
            sound[0] = game.SFX_valu;
            sound[1] = game.BGM_valu;
        }

        return sound;
    }




    public void StartJson()
    {
        ProGame progameInfo = new ProGame()
        {
            BGM_valu = 1,
            SFX_valu = 1,
            tontai = 0,
        };

        string datanew = JsonConvert.SerializeObject(progameInfo);
        Debug.Log(datanew + " :dataNew");

        string dataSvae = Encry(datanew);
        Debug.Log(dataSvae + " :data save");


        string dataTest = Encry_(dataSvae);
        Debug.Log(dataTest + " :data Test");

        using (StreamReader r = new StreamReader(filepath))
        {
            string json = r.ReadToEnd();
            if (json.Length > 2)
            {
                string json_ = "";
                for (int i = 1; i < json.Length - 1; i++)
                {
                    json_ += json[i];
                }
                var loadData = Encry_(json_);
                ProGame game = JsonConvert.DeserializeObject<ProGame>(loadData);
                if (game.tontai != null)
                {
                    return;
                }
            }
        }
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, dataSvae);
        }
    }


    public class ProGame
    {
        public float BGM_valu { get; set; }
        public float SFX_valu { get; set; }
        public int tontai { get; set; }
    }
}
