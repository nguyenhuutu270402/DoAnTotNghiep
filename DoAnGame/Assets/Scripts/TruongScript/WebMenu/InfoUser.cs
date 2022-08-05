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

    public DatabaseGameAccount data;

    public static InfoUser Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameAccounts gameAccount = data.GetGameAccounts(0);
        userName.text = gameAccount.name;
        userPrice.text = "Price :" + gameAccount.price + "";
        userPoints.text = "Points :" + gameAccount.points + "";
    }

    public void updateName(string _name)
    {
        userName.text = _name;
    }
    public void quitAccount()
    {
        data.quitAccount();
        SceneManager.LoadScene(0);
    }
}
