using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRegister : MonoBehaviour
{
    public DatabaseCharacter data;
    public DatabaseGameAccount _data;
    private void Awake()
    {
        data.reset();
        _data.quitAccount();
    }
    private void Start()
    {
        Screen.SetResolution(600, 700, false);
    }
    public void CickWebRegister()
    {
        Application.OpenURL("http://localhost:3000/register-user");
    }
    public void CickWebForgot()
    {
        Application.OpenURL("http://localhost:3000/register-user");
    }
}
