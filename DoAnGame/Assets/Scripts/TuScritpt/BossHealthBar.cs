using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject gobjHB;
    public Text txtName;

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
