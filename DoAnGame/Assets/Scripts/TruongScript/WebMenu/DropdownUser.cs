using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownUser : MonoBehaviour
{
    public TMP_Dropdown Drop;

    public TMP_InputField username;
    public TMP_InputField password;

    private int index = 0;

    private List<string> dataUser;
    private List<string> dataPass;

    void Start()
    {   
        Drop.ClearOptions();

        dataUser = JsonUser.Instance.getUser();
        dataPass = JsonUser.Instance.getPass();

        Drop.AddOptions(dataUser);
        if(dataUser.Count > 0)
        {
            username.text = dataUser[0] + "";
            password.text = dataPass[0] + "";
        }
    }

    void Update()
    {
        if(Drop.value != index && dataUser.Count > 0)
        {
            username.text = dataUser[Drop.value] + "";
            password.text = dataPass[Drop.value] + "";
        }
    }
}
