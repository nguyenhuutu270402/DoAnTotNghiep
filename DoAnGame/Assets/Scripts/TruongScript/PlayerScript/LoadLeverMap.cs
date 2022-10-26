using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLeverMap : MonoBehaviour
{
    public Image IMG;
    public Sprite IMG1, IMG2, IMG3;
    public TextMeshProUGUI NameMap;
    public GameObject load1, load2;
    private int SceneMap = 3;
    public TextMeshProUGUI ModeMap;
    private int Mode = 1;

    private int M01_1 = 0;
    private int M01_2 = 0;
    private int M02_1 = 0;
    private int M02_2 = 0;
    private int M03_1 = 0;
    private int M03_2 = 0;

    public TextMeshProUGUI PointsMax;

    private void Awake()
    {
        M01_1 = PlayerPrefs.GetInt("M01_1");
        M01_2 = PlayerPrefs.GetInt("M01_2");
        M02_1 = PlayerPrefs.GetInt("M02_1");
        M02_2 = PlayerPrefs.GetInt("M02_2");
        M03_1 = PlayerPrefs.GetInt("M03_1");
        M03_2 = PlayerPrefs.GetInt("M03_2");
        Debug.Log(M01_1 + " : " + M01_2 + " : " + M02_1 + " : " + M02_2 + " : " + M03_1 + " : " + M03_2 );
    }

    void Start()
    {   
        Switch(SceneMap);
        ModeMap.text = "normal mode";
        PlayerPrefs.SetInt("ModeMap", Mode);
        PlayerPrefs.SetString("map_id", "M01");
        PlayerPrefs.SetInt("SceneMap", SceneMap);

        Debug.Log("map_id: " + PlayerPrefs.GetString("map_id"));
    }
    public void ClickNextSceneMap()
    {
        SceneMap++;
        PlayerPrefs.SetInt("SceneMap", SceneMap);
        if (SceneMap > 5)
        {
            SceneMap = 3;
        }
        Switch(SceneMap);
        Debug.Log("map_id: " + PlayerPrefs.GetString("map_id"));
    }
    public void ClickBackSceneMap()
    {
        SceneMap--;
        PlayerPrefs.SetInt("SceneMap", SceneMap);
        if (SceneMap < 3)
        {
            SceneMap = 5;
        }
        Switch(SceneMap);
        Debug.Log("map_id: " + PlayerPrefs.GetString("map_id"));
    }
    public void Switch(int map)
    {
        switch (map)
        {
            case 3:
                IMG.sprite = IMG1;
                NameMap.text = "M01";
                PlayerPrefs.SetString("map_id", "M01");
                setPointsMax(M01_1, M01_2);
                break;
            case 4:
                IMG.sprite = IMG2;
                NameMap.text = "M02";
                PlayerPrefs.SetString("map_id", "M02");
                setPointsMax(M02_1, M02_2);
                break;
            case 5:
                IMG.sprite = IMG3;
                NameMap.text = "M03";
                PlayerPrefs.SetString("map_id", "M03");
                setPointsMax(M03_1, M03_2);
                break;
            default:
                break;
        }
    }
    public void setPointsMax(int normal, int hard)
    {
        Debug.Log("vaooooo : " + Mode);
        if (Mode == 1)
        {
            PointsMax.text = normal + "";
        }
        if(Mode == 2)
        {
            PointsMax.text = hard + "";
        }
    }

    public void StartSceneMap()
    {
        load1.SetActive(true);
        load2.SetActive(true);
        LeanTween.moveX(load1, 6f, 0.5f);
        LeanTween.moveX(load2, -6f, 0.5f).setOnComplete(() =>
        {
            SceneManager.LoadScene(SceneMap);
        }); 
    }
    public void ClickModeMap()
    {
        Mode++;
        if (Mode > 2) Mode = 1;
        PlayerPrefs.SetInt("ModeMap", Mode);
        if (Mode == 1)
        {
            ModeMap.text = "normal mode";
        }
        else
        {
            ModeMap.text = "hard mode";
        }
        Switch(SceneMap);
        
        Debug.Log("mode" + PlayerPrefs.GetInt("ModeMap"));
        Debug.Log("SceneMap" + SceneMap);

    }
}
