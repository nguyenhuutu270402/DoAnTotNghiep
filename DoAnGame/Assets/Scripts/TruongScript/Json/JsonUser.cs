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
            string json_ = "";
            for (int i = 1; i < json.Length - 1; i++)
            {
                json_ += json[i];
            }
            var loadData = Encry_(json_);
            users = JsonConvert.DeserializeObject<List<ProGame>>(loadData);
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
            string json_ = "";
            for (int i = 1; i < json.Length - 1; i++)
            {
                json_ += json[i];
            }
            var loadData = Encry_(json_);
            users = JsonConvert.DeserializeObject<List<ProGame>>(loadData);
            if (users == null)
            {
                users = new List<ProGame>();
                return data;
            }
        }
        for (int i = 0; i < users.Count; i++)
        {
            data.Add(users[i].password);
        }
        return data;
    }
    public int checkUserPass(string user, string pass)
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

            string json_ = "";
            for (int i = 1; i < json.Length - 1; i++)
            {
                json_ += json[i];
            }
            var loadData = Encry_(json_);
            games = JsonConvert.DeserializeObject<List<ProGame>>(loadData);

            // kiem tra username ton tai
            if (games == null) games = new List<ProGame>();
            check = games.Find(i => i.username == user);

            if (check != null)
            {
                PlayerPrefs.SetString("user_name", check.username);
                PlayerPrefs.SetString("user_password", check.password);
            }  
        }


        return 1;
    }
    public void DeleteUser(string user )
    {
        var games = new List<ProGame>();
        using (StreamReader r = new StreamReader(filepath))
        {
            var json = r.ReadToEnd();

            string json_ = "";
            for (int i = 1; i < json.Length - 1; i++)
            {
                json_ += json[i];
            }
            var loadData = Encry_(json_);
            games = JsonConvert.DeserializeObject<List<ProGame>>(loadData);
            // kiem tra username ton tai
            if (games == null) games = new List<ProGame>();
            check = games.Find(i => i.username == user);
            if (check != null)
            {
                games.Remove(check);
            }
        }

        string datanew = JsonConvert.SerializeObject(games);
        //Debug.Log(datanew + " :dataNew");

        string dataSvae = Encry(datanew);
        //Debug.Log(dataSvae + " :data save");

        string dataTest = Encry_(dataSvae);
        //Debug.Log(dataTest + " :data Test");

        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, dataSvae);
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

            string json_ = "";
            for (int i = 1; i < json.Length - 1; i++)
            {
                json_ += json[i];
            }
            var loadData = Encry_(json_);
            games = JsonConvert.DeserializeObject<List<ProGame>>(loadData);

            // kiem tra username ton tai
            if (games == null) games = new List<ProGame>();
        }

        check = games.Find(i => i.username == user);
        if (check != null)
        {
            foreach (var item in games)
            {
                if (item.username == check.username)
                {
                    item.password = pass;
                    Debug.Log(item.username + " : " + item.password + " saver pass new ");
                }
            }
            string _datanew = JsonConvert.SerializeObject(games);
            string _dataSvae = Encry(_datanew);
            using (StreamWriter file = File.CreateText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _dataSvae);
            }
            return;
        }

        games.Add(game);

        PlayerPrefs.SetString("user_name", user);
        PlayerPrefs.SetString("user_password", pass);

        string datanew = JsonConvert.SerializeObject(games);
        //Debug.Log(datanew + " :dataNew");

        string dataSvae = Encry(datanew);
        //Debug.Log(dataSvae + " :data save");

        string dataTest = Encry_(dataSvae);
        //Debug.Log(dataTest + " :data Test");


        using (StreamWriter file = File.CreateText(filepath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, dataSvae);
        }
    }

    public class EncryData
    {
        public string data;
    }


    public class ProGame
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
