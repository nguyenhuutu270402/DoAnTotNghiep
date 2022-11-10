using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    private string pathPoint = "http://localhost:3000/api/point-user/";
    private string UserID;

    private string pathCharacter = "http://localhost:3000/api/character-user/";
    private string pathOpenCharacter = "http://localhost:3000/api/get-character";
    private string pathArrPriceCharacter = "http://localhost:3000/api/price-character";
    private string pathOpenWeapon = "http://localhost:3000/api/open-weapons";

    private float time = 2f;
    public Slider slider;
    private float _time = 0f;
    private bool check = false;

    public static GetData Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (check)
        {
            _time += Time.deltaTime;
            slider.value = _time / time;
            if (time - _time <= 0)
            {
                SceneManager.LoadScene(1);
                
            }
        }
    }
    public void checkLoading()
    {
        
        UserID = PlayerPrefs.GetString("UserID");
        StartCoroutine(GetPoints());

        StartCoroutine(GetCharacters());

        StartCoroutine(GetOpenCharacters());

        StartCoroutine(GetArrPriceCharacters());

        StartCoroutine(GetOpenWeapon());
        check = true;
    }


    public IEnumerator GetPoints()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{pathPoint}{UserID}/get"))
        {
            yield return www.SendWebRequest();
            GameAccountPoint Points = JsonUtility.FromJson<GameAccountPoint>(www.downloadHandler.text);
            PlayerPrefs.SetInt("M01_1", Points.point[0]);
            PlayerPrefs.SetInt("M01_2", Points.point[1]);
            PlayerPrefs.SetInt("M02_1", Points.point[2]);
            PlayerPrefs.SetInt("M02_2", Points.point[3]);
            PlayerPrefs.SetInt("M03_1", Points.point[4]);
            PlayerPrefs.SetInt("M03_2", Points.point[5]);
            int M00_0 = 0;
            for (int i = 0; i < Points.point.Length; i++)
            {
                if(M00_0 < Points.point[i])
                {
                    M00_0 = Points.point[i];
                }
            }
            PlayerPrefs.SetInt("M00_0", M00_0);
            //Debug.Log("GetPoints" + M00_0);
        }
    }
    private IEnumerator GetCharacters()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{pathCharacter}{UserID}/get"))
        {
            yield return www.SendWebRequest();
            GameAccountCharacter character = JsonUtility.FromJson<GameAccountCharacter>(www.downloadHandler.text);
            Debug.Log(character.data.Length);
            int length = character.data.Length;
            if(length == 0)
            {
                PlayerPrefs.SetInt("skin1", 0);
                PlayerPrefs.SetInt("skin2", 0);
            }
            if(length == 1)
            {
                PlayerPrefs.SetInt("skin1", character.data[0]);
                PlayerPrefs.SetInt("skin2", 0);
            }
            if(length == 2)
            {
                PlayerPrefs.SetInt("skin1", character.data[0]);
                PlayerPrefs.SetInt("skin2", character.data[1]);
            }
            Debug.Log(PlayerPrefs.GetInt("skin1") + " : " +  PlayerPrefs.GetInt("skin2") + " :GetCharacters: ");
            
        }
    }
    private IEnumerator GetOpenCharacters()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{pathOpenCharacter}"))
        {
            yield return www.SendWebRequest();
            GameAccountOpen Open = JsonUtility.FromJson<GameAccountOpen>(www.downloadHandler.text);
            PlayerPrefs.SetInt("OpenCharacter_1", Open.open[0]);
            PlayerPrefs.SetInt("OpenCharacter_2", Open.open[1]);
            PlayerPrefs.SetInt("OpenCharacter_3", Open.open[2]);
            PlayerPrefs.SetInt("OpenCharacter_4", Open.open[3]);
            PlayerPrefs.SetInt("OpenCharacter_5", Open.open[4]);
            PlayerPrefs.SetInt("OpenCharacter_6", Open.open[5]);
            Debug.Log(Open.open[0] + " : " + Open.open[1] + " : " + Open.open[2] + " : " + Open.open[3] + " : " + Open.open[4] + " : " + Open.open[5] + " :GetOpenCharacters: ");
        }
    }
    private IEnumerator GetArrPriceCharacters()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{pathArrPriceCharacter}"))
        {
            yield return www.SendWebRequest();
            GameAccountArrPriceCharacter arrPrice = JsonUtility.FromJson<GameAccountArrPriceCharacter>(www.downloadHandler.text);
            PlayerPrefs.SetInt("arrPrice_1", arrPrice.arrPrice[0]);
            PlayerPrefs.SetInt("arrPrice_2", arrPrice.arrPrice[1]);
            Debug.Log(arrPrice.arrPrice[1] + " : " + arrPrice.arrPrice[1] + " :GetArrPriceCharacters: ");
        }
    }
    private IEnumerator GetOpenWeapon()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{pathOpenWeapon}"))
        {
            yield return www.SendWebRequest();
            GameAccountOpen Open = JsonUtility.FromJson<GameAccountOpen>(www.downloadHandler.text);
            PlayerPrefs.SetInt("OpenWeapon_1", Open.open[0]);
            PlayerPrefs.SetInt("OpenWeapon_2", Open.open[1]);
            PlayerPrefs.SetInt("OpenWeapon_3", Open.open[2]);
            PlayerPrefs.SetInt("OpenWeapon_4", Open.open[3]);
            PlayerPrefs.SetInt("OpenWeapon_5", Open.open[4]);
            PlayerPrefs.SetInt("OpenWeapon_6", Open.open[5]);
            Debug.Log(Open.open[0] + " : " + Open.open[1] + " : " + Open.open[2] + " : " + Open.open[3] + " : " + Open.open[4] + " : " + Open.open[5] + " :GetOpenWeapon: ");
        }
    }
}