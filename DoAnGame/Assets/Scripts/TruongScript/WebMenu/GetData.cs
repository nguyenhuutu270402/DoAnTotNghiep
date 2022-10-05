using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetData : MonoBehaviour
{
    private string pathPoint = "http://localhost:3000/api/point-user/";
    private string UserID;

    private string pathCharacter = "http://localhost:3000/api/product-user/";



    private IEnumerator coroutinePoint;
    private IEnumerator coroutineCharacter;

    void Start()
    {
        UserID = PlayerPrefs.GetString("UserID");
        coroutinePoint = GetPoints();
        StartCoroutine(coroutinePoint);

        coroutineCharacter = GetCharacters();
        StartCoroutine(coroutineCharacter);
    }

    private IEnumerator GetPoints()
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
            Debug.Log(PlayerPrefs.GetInt("skin1") + " : " +  PlayerPrefs.GetInt("skin2") + " :getData: ");
            
        }
    }

}