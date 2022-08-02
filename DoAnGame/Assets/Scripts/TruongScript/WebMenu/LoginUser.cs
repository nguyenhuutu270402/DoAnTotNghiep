using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginUser : MonoBehaviour
{

    [SerializeField] private string authen = "http://localhost:3000/api/login-user";
    [SerializeField] private TMP_InputField UserNameInput;
    [SerializeField] private TMP_InputField PassWordInput;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void onLogin()
    {
        StartCoroutine(Login_unity());
    }
    private IEnumerator Login_unity()
    {
        string username = UserNameInput.text.Trim();
        string password = PassWordInput.text.Trim();
        if (username.Length == 0)
        {
            username = "0";
        }
        if (password.Length == 0)
        {
            password = "0";
        }
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/api/login-user", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                GameAccount account = JsonUtility.FromJson<GameAccount>(www.downloadHandler.text);
                Debug.Log(account.statusName);
                if (account.statusName == "false")
                {
                    Screen.SetResolution(1920, 1080, true);
                    SceneManager.LoadScene(1);
                    yield return null;
                }
                else if (account.status == "true")
                {
                    Screen.SetResolution(1920 , 1080, true);
                    SceneManager.LoadScene(2);
                    yield return null;
                }
            }
        }
    }
}
