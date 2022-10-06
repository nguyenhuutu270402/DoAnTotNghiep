using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject explode;
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextHightScore;



    private int Point = 0;
    private int HighPoint = 0;
    private string texthighPoint = "";
    private int userPrice;
    private bool check = false;
    private void Awake()
    {
        userPrice = PlayerPrefs.GetInt("UserPrice");
        GetHighPoint();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 | collision.gameObject.layer == 10)
        {
            if (!check)
            {
                StartCoroutine(explodePlayer());
                check = true;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11 | collision.gameObject.layer == 10)
        {
            if (!check)
            {
                StartCoroutine(explodePlayer());
                check = true;
            }
        }
    }
    IEnumerator explodePlayer()
    {
        
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        // c?p nh?t price t?ng
        userPrice += Point;
        Debug.Log(userPrice + "Desstroy");
        PlayerPrefs.SetInt("UserPrice", userPrice);
        Debug.Log(PlayerPrefs.GetInt("UserPrice") + "Desstroy1");
        // check ?i?m m�n ch?i n�y c� cao h?n ?i?m cao nh?t kh�ng
        checkPoint(Point, HighPoint);
        
        Instantiate(explode, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameOver.SetActive(true);
        Destroy(gameObject);
        Time.timeScale = 0f;
        
    }

    private void checkPoint(int _point, int _highhPoint)
    {
        if(_point > _highhPoint)
        {
            TextScore.text = Point + "!";
            TextScore.color = Color.red;
            Debug.Log("Destroy red: " + Point);
            PlayerPrefs.SetInt("texthighPoint", _point);
            Updata.Instance.upPoint(); 
            Updata.Instance.upPointUser();
        }
        else
        {
            TextScore.text = Point + "";
            TextScore.color = Color.black;
            Debug.Log("Destroy black: " + Point);
            Updata.Instance.upPointUser();
        }

    }

    private void Update()
    {
        Point = PlayerPrefs.GetInt("Score");
    }


    public void GetHighPoint()
    {
        int ModeMap = PlayerPrefs.GetInt("ModeMap");
        string map_id = PlayerPrefs.GetString("map_id");
        texthighPoint = map_id + "_" + ModeMap;
        Debug.Log(texthighPoint + "    : GetHighPoint");
        Switch(texthighPoint);
        TextHightScore.text = HighPoint + "";
        Debug.Log(HighPoint + " :setHighPoint");

    }
    public void Switch(string _highPoint)
    {
        switch (_highPoint)
        {
            case "M01_1":
                HighPoint = PlayerPrefs.GetInt("M01_1");
                break;
            case "M01_2":
                HighPoint = PlayerPrefs.GetInt("M01_2");
                break;
            case "M02_1":
                HighPoint = PlayerPrefs.GetInt("M02_1");
                break;
            case "M02_2":
                HighPoint = PlayerPrefs.GetInt("M02_2");
                break;
            case "M03_1":
                HighPoint = PlayerPrefs.GetInt("M03_1");
                break;
            case "M03_2":
                HighPoint = PlayerPrefs.GetInt("M03_2");
                break;
            default:
                break;
        }
    }



    public void Retry()
    {
        Time.timeScale = 1f;
        int SceneMap = PlayerPrefs.GetInt("SceneMap");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneMap);
    }
}
