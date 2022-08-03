using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UpdateName : MonoBehaviour
{
    public GameAccountDatabase data;
    [SerializeField] private TMP_InputField NameUpdate;
    private string path = "http://localhost:3000/api/";
    public GameObject Menu;
    public GameObject MenuName;
    public GameObject MenuInfo;
    public Button BtnSave;
    void Start()
    {
        
    }

    
    void Update()
    {
        string name = NameUpdate.text.Trim();
        if(name.Length < 1)
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
        GameAccount gameAccount = data.GetGameAccounts(0);
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        using (UnityWebRequest www = UnityWebRequest.Post($"{path}{gameAccount.id}/edit", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                GameAccount account = JsonUtility.FromJson<GameAccount>(www.downloadHandler.text);
                if (account.status == "true")
                {
                    Menu.SetActive(true);
                    MenuInfo.SetActive(true);
                    MenuName.SetActive(false);
                    data.setName(name);
                    
                    yield return null;
                }else if(account.status == "false")
                {
                    Menu.SetActive(false);
                    MenuInfo.SetActive(false);
                    MenuName.SetActive(true);
                    yield return null;
                }
            }
            www.Dispose();
        }
    }
}
