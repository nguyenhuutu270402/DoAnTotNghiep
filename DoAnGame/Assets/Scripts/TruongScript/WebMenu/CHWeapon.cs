using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CHWeapon : MonoBehaviour
{
    private int index = 10;
    public TextMeshProUGUI NameWeapon;
    private int maxWeapon = 3;
    void Start()
    {   
        index = 10;
        upWeapon();
    }
    private void FixedUpdate()
    {
        maxWeapon = PlayerPrefs.GetInt("maxWeapon");
    }

    private void upWeapon()
    {
        NameWeapon.text = transform.GetChild(index).name;
        transform.GetChild(index).transform.gameObject.SetActive(true);
        if(index > maxWeapon)
        {
            NameWeapon.text = "???";
            transform.GetChild(index).transform.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (index == 10)
        {
            NameWeapon.text = transform.GetChild(index).name;
            transform.GetChild(index).transform.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    public void next() {
        transform.GetChild(index).transform.gameObject.SetActive(false);
        index++;
        if(index > 10)
        {
            index = 0;
        }
        upWeapon();
    }
    public void prev() {
        transform.GetChild(index).transform.gameObject.SetActive(false);
        index--;
        if(index < 0)
        {
            index = 10;
        }
        upWeapon();
    }
}
