using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Updata : MonoBehaviour
{
    private string path = "http://localhost:3000/api/";
    public static Updata Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }


    public void upPoint()
    {
        StartCoroutine(updatePoint());
    }
    private IEnumerator updatePoint()
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", PlayerPrefs.GetString("UserID") );
        form.AddField("map_id", PlayerPrefs.GetString("map_id") );
        form.AddField("point", PlayerPrefs.GetInt("Score") );
        form.AddField("level", PlayerPrefs.GetInt("ModeMap") );
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/api/point-user/save", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            yield return null;
        }
    }
    public void upPointUser()
    {
        StartCoroutine(updatePointUser());
    }
    private IEnumerator updatePointUser()
    {
        string UserID = PlayerPrefs.GetString("UserID");
        WWWForm form = new WWWForm();
        form.AddField("points", PlayerPrefs.GetInt("UserPoints"));
        using (UnityWebRequest www = UnityWebRequest.Post($"{path}{UserID}/edit", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            yield return null;
        }
    }

    public void upPriceBoss()
    {
        StartCoroutine(updatePriceBoss());
    }
    private IEnumerator updatePriceBoss()
    {
        int PriceBoss = PlayerPrefs.GetInt("PriceBoss");
        WWWForm form = new WWWForm();
        form.AddField("user_id", PlayerPrefs.GetString("UserID"));
        form.AddField("price", PriceBoss);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/api/add-price", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            yield return null;
        }
    }
}
