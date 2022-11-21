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
    private int userPoints;
    private bool check = false;
    private void Awake()
    {
        userPoints = PlayerPrefs.GetInt("UserPoints");
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
        // cap nhat tong  points cua user
        Point = PlayerPrefs.GetInt("Score");
        userPoints += Point;
        PlayerPrefs.SetInt("UserPoints", userPoints);
        checkPoint(Point, HighPoint);
        checkM00_0(Point);
        TextHightScore.text = HighPoint + "";
        upDataPriceBoss();
        GameObject explode_ = Instantiate(explode, gameObject.transform.position, Quaternion.identity);
        Destroy(explode_, 0.05f);
        yield return new WaitForSeconds(0.5f);
        GameOver.SetActive(true);
        Destroy(gameObject);
        Time.timeScale = 0f;

    }
    private void upDataPriceBoss()
    {
        // cap nhat price
        int UserPrice = PlayerPrefs.GetInt("UserPrice");
        int PriceBoss = PlayerPrefs.GetInt("PriceBoss");
        if(PriceBoss > 0)
        {
            Updata.Instance.upPriceBoss();
            UserPrice += PriceBoss;
            PlayerPrefs.SetInt("UserPrice", UserPrice);
        }
    }
    private void checkM00_0(int _Point)
    {
        // check points cao nhat 3 map va 2 che do
        int M00_0 = PlayerPrefs.GetInt("M00_0");
        if (_Point > M00_0)
        {
            PlayerPrefs.SetInt("M00_0", Point);
        }
    }

    private void checkPoint(int _point, int _highhPoint)
    {
        // kiem tra xem diem man nay co phai diem cao nhat khong va updata
        Updata.Instance.upPointUser();
        if (_point > _highhPoint)
        {
            TextScore.text = Point + "!";
            TextScore.color = Color.red;

            PlayerPrefs.SetInt(texthighPoint, _point);
            Updata.Instance.upPoint();
        }
        else
        {
            TextScore.text = Point + "";
            TextScore.color = Color.black;
        }
    }

    public void GetHighPoint()
    {
        int ModeMap = PlayerPrefs.GetInt("ModeMap");
        string map_id = PlayerPrefs.GetString("map_id");
        Debug.Log(map_id + " : " + ModeMap + "Destroy player");
        texthighPoint = map_id + "_" + ModeMap;
        Switch(texthighPoint);
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
