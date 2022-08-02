using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMenu : MonoBehaviour
{
    public GameObject MenuPresent;
    public GameObject MenuBefore;
    float TimeScale = 0.3f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            back();
        }
    }
    public void click()
    {
        LeanTween.scale(MenuPresent, new Vector3(0, 0, 0), TimeScale).setOnComplete(() => { 
            MenuPresent.SetActive(false);
            MenuBefore.SetActive(true);
            LeanTween.scale(MenuBefore, new Vector3(1, 1, 1), TimeScale);
        });
    }
    public void back()
    {
        LeanTween.scale(MenuBefore, new Vector3(0, 0, 0), TimeScale).setOnComplete(() => {
            MenuBefore.SetActive(false);
            MenuPresent.SetActive(true);
            LeanTween.scale(MenuPresent, new Vector3(1, 1, 1), TimeScale);
        });
    }
}
