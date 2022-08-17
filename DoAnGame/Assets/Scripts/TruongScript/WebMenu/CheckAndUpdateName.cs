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
    public DatabaseGameAccount data;
    public Button BtnSave;

    [SerializeField] private TMP_InputField NameUpdate;
    private string path = "http://localhost:3000/api/";

    private GameAccounts game;

    void Start()
    {
        game = data.GetGameAccounts(0);
        if (game.name.Length >= 6)
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
        if (name.Length < 6)
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
        GameAccounts gameAccount = data.GetGameAccounts(0);
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
                GameAccounts account = JsonUtility.FromJson<GameAccounts>(www.downloadHandler.text);
                if (account.status)
                {
                    Menu.SetActive(true);
                    MenuName.SetActive(false);
                    data.setName(name);
                    InfoUser.Instance.updateName(name);

                    yield return null;
                }
                else if (!account.status)
                {
                    Menu.SetActive(false);
                    MenuName.SetActive(true);
                    yield return null;
                }
            }
        }
    }
}
