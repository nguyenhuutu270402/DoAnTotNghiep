using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject gobjHB;
    public Text txtName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }

    public void setBossName(string name)
    {
        txtName.text = name;
    }

    public void setActiveBarBoss()
    {
        gobjHB.SetActive(false);
    }
}
