using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonManager : MonoBehaviour
{
    private string filepath = "ProGame.json";



    public static JsonManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartJson();
    }
    void Update()
    {
        
    }
    public void updateSounds(float value, int index)
    {
        // 0 : SFX
        // 1 : BGM
        var progames = StreamReader();
        if (index == 0)
        {
            foreach (var item in progames)
            {
                item.SFX_valu = value;
            }
        }
        else if(index == 1)
        {
            foreach (var item in progames)
            {
                item.BGM_valu = value;
            }
        }
        StreamWriter(progames);
    }
    public void updateLanguage(int value)
    {
        var progames = StreamReader();
        foreach (var item in progames)
        {
            item.language = value;
        }
        StreamWriter(progames);
    }
    public void updateFullscene(bool full)
    {
        var progames = StreamReader();
        foreach (var item in progames)
        {
            item.fullscene = full;
        }
        StreamWriter(progames);
    }
    public float[] getSounds()
    {
        // 0 : SFX
        // 1 : BGM
        float[] sound = new float[2];
        var progames = StreamReader();
        foreach (var item in progames)
        {
            sound[0] = item.SFX_valu;
            sound[1] = item.BGM_valu;
        }
        return sound;
    }
    public int getLanguage()
    {   // 0 : english
        // 1 : vietnamese
        int lang = 0;
        var progames = StreamReader();
        foreach (var item in progames)
        {
            lang = item.language;
        }
        return lang;
    }
    public bool getFullscene()
    {   
        // false : ko full
        // true : full
        bool full = false;
        var progames = StreamReader();
        foreach (var item in progames)
        {
            full = item.fullscene;
        }
        return full;
    }
    public List<ProGame> StreamReader()
    {
        var progames = new List<ProGame>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            progames = JsonConvert.DeserializeObject<List<ProGame>>(json);
        }
        return progames;
    }
    public void StreamWriter(List<ProGame> proGames)
    {
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, proGames);
        }
    }
    public void StartJson()
    {
       ProGame progameInfo = new ProGame()
       {
           BGM_valu = 1,
           SFX_valu = 1,
           language = 0,
           tontai = 0,
           fullscene = false,
       };
        
        var progames = new List<ProGame>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            progames = JsonConvert.DeserializeObject<List<ProGame>>(json);
            // kiem tra username ton tai
            if (progames == null) progames = new List<ProGame>();
            var check = progames.Find(i => i.tontai == 0);
            if (check != null)
            {
                return;
            }
        }
        progames.Add(progameInfo);
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, progames);
        }
    }
    public class ProGame
    {
        public float BGM_valu { get; set; }
        public float SFX_valu { get; set; }
        public int language { get; set; }
        public int tontai { get; set; }
        public bool fullscene { get; set; }
    }
}