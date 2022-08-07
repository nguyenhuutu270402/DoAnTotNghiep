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


    private List<string> dataUser;
    private List<string> dataPass;

    public static DropdownUser Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {   
        Drop.ClearOptions();
        
        dataUser = JsonUser.Instance.getUser();
        dataPass = JsonUser.Instance.getPass();
        Drop.AddOptions(dataUser);

        Drop.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Drop);
        });
        if(Drop.options.Count > 0)
        {
            username.text = dataUser[0] + "";
            password.text = dataPass[0] + "";
        }
    }
    
    void DropdownValueChanged(TMP_Dropdown change)
    {
        username.text = dataUser[change.value] + "";
        password.text = dataPass[change.value] + "";
    }
    public void updateOptions()
    {
        Drop.Hide();
        dataUser = JsonUser.Instance.getUser();
        dataPass = JsonUser.Instance.getPass();
        Drop.ClearOptions();
        Drop.AddOptions(dataUser);
    }







}
