using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebRegister : MonoBehaviour
{
    
    public void CickWebRegister()
    {
        Application.OpenURL("http://localhost:3000/register-user");
    }
    public void CickWebForgot()
    {
        Application.OpenURL("http://localhost:3000/register-user");
    }
}
