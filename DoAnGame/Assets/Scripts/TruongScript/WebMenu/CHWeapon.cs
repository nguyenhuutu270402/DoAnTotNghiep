using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CHWeapon : MonoBehaviour
{
    private int index = 10;
    public TextMeshProUGUI NameWeapon;
    void Start()
    {   
        index = 10;
        transform.position = new Vector3(0, -60, 0);
        upWeapon();
    }


    private void upWeapon()
    {
        NameWeapon.text = transform.GetChild(index).name;
        transform.GetChild(index).transform.gameObject.SetActive(true);
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
