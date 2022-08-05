using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OperationeMenuMap : MonoBehaviour
{
    public GameObject MenuPause;
    public GameObject MenuSettings;
    [SerializeField]

    public GameObject load1, load2;

    private void Awake()
    {
        LeanTween.moveX(load1, 3000f, 3f);
        LeanTween.moveX(load2, -1000f, 3f);
    }
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuPause.active)
        {
            MenuPause.SetActive(true);
            TimePause(0);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && MenuPause.active && !MenuSettings.active)
        {
            MenuPause.SetActive(false);
            TimePause(1);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && MenuSettings.active)
        {
            MenuSettings.SetActive(false);
            MenuPause.SetActive(true);
        }
    }

    public void BackMenu()
    {
        MenuSettings.SetActive(false);
        MenuPause.SetActive(true);
    }
    
    public void BtnBackToTitle()
    {
        SceneManager.LoadScene(1);
        TimePause(1);        
    }

    public void BtnSetting()
    {
        MenuSettings.SetActive(true);
        MenuPause.SetActive(false);       
    }
    public void BtnResume()
    {
        MenuPause.SetActive(false);
        TimePause(1);       
    }
    public void TimePause(int time)
    {
        Time.timeScale = time;
    }
}
