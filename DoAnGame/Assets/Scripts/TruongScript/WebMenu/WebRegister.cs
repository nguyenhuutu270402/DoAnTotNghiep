using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRegister : MonoBehaviour
{
    private void Awake()
    {

    }
    private void Start()
    {
        Screen.SetResolution(600, 700, false);
    }
    public void CickWebRegister()
    {
        Application.OpenURL("http://34.150.93.73/register-user");
    }
    public void CickWebForgot()
    {
        Application.OpenURL("http://34.150.93.73/check-user");
    }
}
