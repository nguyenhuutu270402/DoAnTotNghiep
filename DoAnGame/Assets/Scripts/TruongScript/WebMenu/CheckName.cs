using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckName : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuName;
    public GameObject MenuInfo;
    public GameAccountDatabase data;
    void Start()
    {
        GameAccount gameAccount = data.GetGameAccounts(0);
        if(gameAccount.name.Length > 2)
        {
            Menu.SetActive(true);
            MenuInfo.SetActive(true);
            MenuName.SetActive(false);
        }
        else
        {
            Menu.SetActive(false);
            MenuInfo.SetActive(false);
            MenuName.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
