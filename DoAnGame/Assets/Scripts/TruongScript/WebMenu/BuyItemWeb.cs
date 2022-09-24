﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class BuyItemWeb : MonoBehaviour
{
    private int id;
    public GameObject Dino;
    public GameObject Confirm;
    public GameObject Erro;
    public static BuyItemWeb Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyItem(int _id)
    {
        id = _id;
    }
    public void ConfirmWeb()
    {
        int UserPrice = PlayerPrefs.GetInt("UserPrice");
        if(UserPrice < 150)
        {
            Erro.SetActive(true);
        }
        else
        {
            StartCoroutine(BUY());
        }

       
        
    }
    private IEnumerator BUY()
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", PlayerPrefs.GetString("UserID"));
        form.AddField("product_id", id);
        form.AddField("price", 150);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/api/reset-price", form))
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
                    Confirm.SetActive(false);
                    Dino.SetActive(true);
                    Debug.Log("mua thành công rồi nhhe");
                    CHPlay.Instance.UpdatePrice(id);
                    CHPlay.Instance.updateCharacter();

                    int UserPrice = PlayerPrefs.GetInt("UserPrice") - 150;
                    PlayerPrefs.SetInt("UserPrice", UserPrice);

                    CharacterUser.Instance.updteCharacter(id);
                    InfoUser.Instance.updatePrice(UserPrice);
                    CHPlay.Instance.updatePrice(UserPrice);

                    yield return null;
                }
                else if (!account.status)
                {
                    Debug.Log("mua thất bại");
                }
            }
        }
    }
}
