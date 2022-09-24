using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CheckAndUpdateName : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MenuName;
    public Button BtnSave;
    public GameObject erro;

    [SerializeField] private TMP_InputField NameUpdate;
    private string path = "http://localhost:3000/api/";
    private string UserName;
    private string UserID;

    void Start()
    {
        UserName = PlayerPrefs.GetString("UserName");
        UserID = PlayerPrefs.GetString("UserID");

        if (UserName.Length >= 6)
        {
            Menu.SetActive(true);
        }
        else
        {
            MenuName.SetActive(true);
        }
    }

    void Update()
    {
        string name = NameUpdate.text.Trim();
        if (name.Length < 6 || name.Length > 20)
        {
            BtnSave.interactable = false;
        }
        else
        {
            BtnSave.interactable = true;
        }
    }
    public void SaveName()
    {
        StartCoroutine(Save());
    }
    private IEnumerator Save()
    {
        string name = NameUpdate.text.Trim();
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        using (UnityWebRequest www = UnityWebRequest.Post($"{path}{UserID}/name", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                GameAccounts account = JsonUtility.FromJson<GameAccounts>(www.downloadHandler.text);
                if (account.status)
                {
                    Menu.SetActive(true);
                    MenuName.SetActive(false);
                    PlayerPrefs.SetString("UserName", name);
                    InfoUser.Instance.updateName(name);
                    yield return null;
                }
                else if (!account.status)
                {
                    erro.SetActive(true);
                    yield return null;
                }
            }
        }
    }
}
