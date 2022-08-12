using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonUser : MonoBehaviour
{
    //private string filepath = "ProGame.json";
    private string filepath = Path.Combine(Application.streamingAssetsPath, "saveuser.json");

    public static JsonUser Instance { get; private set; }

    private ProGame check;

    private void Awake()
    {
        Instance = this;
    }
    public List<string> getUser()
    {
        List<string> data = new List<string> { };

        var users = new List<ProGame>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            users = JsonConvert.DeserializeObject<List<ProGame>>(json);
            if (users == null)
            {
                users = new List<ProGame>();
                return data;
            }
        }
        
        for (int i = 0; i < users.Count; i++)
        {
            data.Add(users[i].username);
        }
        return data;
    }
    public List<string> getPass()
    {
        List<string> data = new List<string> { };

        var users = new List<ProGame>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            users = JsonConvert.DeserializeObject<List<ProGame>>(json);
            if (users == null)
            {
                users = new List<ProGame>();
                return data;
            }
        }
        for (int i = 0; i < users.Count; i++)
        {
            data.Add(users[i].username);
        }
        return data;
    }
    public void DeleteUser(string user )
    {
        var games = new List<ProGame>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            games = JsonConvert.DeserializeObject<List<ProGame>>(json);
            // kiem tra username ton tai
            if (games == null) games = new List<ProGame>();
            check = games.Find(i => i.username == user);
            if (check != null)
            {
                games.Remove(check);
            }
        }
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, games);
        }
    }
    public void SavaUser(string user, string pass)
    {
        ProGame game = new ProGame()
        {
            username = user,
            password = pass,
        };
        var games = new List<ProGame>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();
            games = JsonConvert.DeserializeObject<List<ProGame>>(json);
            // kiem tra username ton tai
            if (games == null) games = new List<ProGame>();
            check = games.Find(i => i.username == user);
            if (check != null)
            {
                return;
            }
        }
        if(check != null)
        {
            foreach (var item in games)
            {
                if (item.username == check.username && item.password != check.password)
                {
                    item.password = pass;
                }
            }
        }
        
        games.Add(game);
        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, games);
        }
    }
    public class ProGame
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}