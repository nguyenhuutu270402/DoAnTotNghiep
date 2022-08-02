using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckName : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuName;
    public GameAccountDatabase data;
    void Start()
    {
        GameAccount gameAccount = data.GetGameAccounts(0);
        if(gameAccount.name != null)
        {
            Menu.SetActive(true);
            MenuName.SetActive(false);
        }
        else
        {
            Menu.SetActive(false);
            MenuName.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
