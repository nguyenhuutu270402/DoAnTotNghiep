using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class BuyItemWeb : MonoBehaviour
{
    private int id;
    private int prite;

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
    public void BuyItem(int _id, int _prite)
    {
        id = _id;
        prite = _prite;
    }
    public void ConfirmWeb()
    {
        int UserPrice = PlayerPrefs.GetInt("UserPrice");
        if(UserPrice < prite)
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
        form.AddField("code", id);
        form.AddField("price", prite);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.150.93.73/api/reset-price", form))
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

                    int skin1 = PlayerPrefs.GetInt("skin1");
                    int skin2 = PlayerPrefs.GetInt("skin2");
                    if (skin1 == 0)
                    {
                        PlayerPrefs.SetInt("skin1", id);
                    }
                    else if (skin2 == 0)
                    {
                        PlayerPrefs.SetInt("skin2", id);
                    }

                    int UserPrice = PlayerPrefs.GetInt("UserPrice") - prite;
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
