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

    void Start()
    {   
        Switch(SceneMap);
        ModeMap.text = "normal mode";
        PlayerPrefs.SetInt("ModeMap", Mode);
    }
    public void ClickNextSceneMap()
    {
        SceneMap++;
        if(SceneMap > 5)
        {
            SceneMap = 3;
        }
        Switch(SceneMap);
    }
    public void ClickBackSceneMap()
    {
        SceneMap--;
        if (SceneMap < 3)
        {
            SceneMap = 5;
        }
        Switch(SceneMap);
    }
    public void Switch(int map)
    {
        switch (map)
        {
            case 3:
                IMG.sprite = IMG1;
                NameMap.text = "1";
                break;
            case 4:
                IMG.sprite = IMG2;
                NameMap.text = "2";
                break;
            case 5:
                IMG.sprite = IMG3;
                NameMap.text = "3";
                break;
            default:
                break;
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
        Debug.Log("mode" + PlayerPrefs.GetInt("ModeMap"));
        
    }
}
