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

    public Button BtnLogin;
    public GameObject TextErro;
    private bool isLogin = false;
    private float startTime = 0.0f;
    public Toggle toggle;

    public GameObject loading;


    void Start()
    {
        TextErro.SetActive(false);
        PlayerPrefs.DeleteAll();
    }
    void Update()
    {
        if(isLogin == true)
        {
            startTime += Time.deltaTime;
            if(startTime >= 3f)
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
                GameAccounts account = JsonUtility.FromJson<GameAccounts>(www.downloadHandler.text);
                Debug.Log(account.status + " : " + account.id + " : " + account.name + " : " + +account.price + " : " + account.points + " : " + account.image );
                if (account.status)
                {
                    PlayerPrefs.SetString("UserID", account.id);
                    PlayerPrefs.SetString("UserName", account.name);
                    PlayerPrefs.SetInt("UserPrice", account.price);
                    PlayerPrefs.SetInt("UserPoints", account.points);
                    PlayerPrefs.SetString("UserImage", account.image);

                    loading.SetActive(true);
                    GetData.Instance.checkLoading();
                    CheckSave(toggle.isOn, username, password);
                    yield return null;
                }else if(!account.status)
                {
                    TextErro.SetActive(true);
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
