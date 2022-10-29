using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoUser : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI userPrice;
    public TextMeshProUGUI userPoints;

    private int UserPrice; 
    private int UserPoints;
    private string UserName;

    public static InfoUser Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UserName = PlayerPrefs.GetString("UserName");
        UserPrice = PlayerPrefs.GetInt("UserPrice");
        UserPoints = PlayerPrefs.GetInt("UserPoints");
        userName.text = "" + UserName;
        userPrice.text = "" + UserPrice + "";
        userPoints.text = "" + UserPoints + "";
    }

    public void updateName(string _name)
    {
        userName.text = _name;
    }
    public void updatePrice(int _price)
    {
        userPrice.text = "" + _price + "";
    }
    public void updatePoint(int _point)
    {
        userPoints.text = "" + _point + "";
    }
    public void quitAccount()
    {
        SceneManager.LoadScene(0);
    }
}
