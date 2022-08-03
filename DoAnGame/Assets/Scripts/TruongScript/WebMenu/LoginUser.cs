using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginUser : MonoBehaviour
{
    [SerializeField] private TMP_InputField UserNameInput;
    [SerializeField] private TMP_InputField PassWordInput;

    public GameAccountDatabase data;
    public Button BtnLogin;
    public GameObject TextErro;
    private bool isLogin = false;
    private float startTime = 0.0f;

    public Toggle toggle;
    void Start()
    {
        TextErro.SetActive(false);
    }
    void Update()
    {

        if(isLogin == true)
        {
            startTime += Time.deltaTime;
            if(startTime >= 5)
            {
                BtnLogin.interactable = true;
                isLogin = false;
                startTime = 0.0f;
            }
        }
    }
    public void onLogin()
    {
        StartCoroutine(Login_unity());
    }
    private IEnumerator Login_unity()
    {
        isLogin = true;
        BtnLogin.interactable = false;


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
                data.insertAccount(account.status, account.statusName, account.id, account.name, account.price, account.points);
                if(account.status == "false")
                {
                    TextErro.SetActive(true);
                }
                else if (account.statusName == "false")
                {
                    Screen.SetResolution(1920, 1080, true);
                    SceneManager.LoadScene(1);
                    CheckSave(toggle.isOn, username, password);
                    yield return null;
                }
                else if (account.status == "true")
                {
                    Screen.SetResolution(1920 , 1080, true);
                    SceneManager.LoadScene(1);
                    CheckSave(toggle.isOn, username, password);
                    yield return null;
                }
            }
        }
        
    }
    public void CheckSave(bool sv, string us, string ps)
    {
        if(sv)
        {
            JsonUser.Instance.SavaUser(us, ps);
        }
    }
}
