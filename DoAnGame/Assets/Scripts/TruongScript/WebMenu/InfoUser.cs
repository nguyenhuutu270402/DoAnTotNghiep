using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUser : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI userPrice;
    public TextMeshProUGUI userPoints;

    public GameAccountDatabase data;
    void Start()
    {
        GameAccount gameAccount = data.GetGameAccounts(0);
        userName.text = gameAccount.name;
        userPrice.text = "Price :" + gameAccount.price + "";
        userPoints.text = "Points :" + gameAccount.points + "";
    }

    
    void Update()
    {
        
    }
}
