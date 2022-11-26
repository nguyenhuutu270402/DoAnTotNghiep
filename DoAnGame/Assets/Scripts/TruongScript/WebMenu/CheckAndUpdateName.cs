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
    public Button BtnCheck;
    public GameObject errCheckLength;
    public TextMeshProUGUI errCheckName;

    [SerializeField] private TMP_InputField NameUpdate;
    private string path = "http://localhost:3000/api/update/name";
    private string pathCheck = "http://localhost:3000/api/check-name";
    private string UserName;
    private string UserID;
    private int price = 0;

    private bool check = false;

    [Header("Card")]
    public TMP_InputField NameUpdateCard;
    public Button BtnSaveCard;
    public Button BtnCheckCard;
    public GameObject errCheckLengthCard;
    public TextMeshProUGUI errCheckNameCard;
    public GameObject tableCard;

    private bool checkCard = false;

    private string Nametemporary = "";

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
        Screen.fullScreen = true;
        Nametemporary = "";
    }

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
        if(name != Nametemporary)
        {
            check = false;
        }

        if (name.Length < 6 || name.Length > 20)
        {
            BtnCheck.interactable = false;
            errCheckLength.SetActive(true);
        }
        else
        {
            BtnCheck.interactable = true;
            errCheckLength.SetActive(false);
        }

        if (check)
        {
            BtnSave.interactable = true;
        }
        else
        {
            BtnSave.interactable = false;
        }
        string nameCard = NameUpdateCard.text.Trim();

        if (nameCard != Nametemporary)
        {
            checkCard = false;
        }

        if (nameCard.Length < 6 || nameCard.Length > 20)
        {
            BtnCheckCard.interactable = false;
            errCheckLengthCard.SetActive(true);
        }
        else
        {
            BtnCheckCard.interactable = true;
            errCheckLengthCard.SetActive(false);
        }

        if (checkCard)
        {
            BtnSaveCard.interactable = true;
        }
        else
        {
            BtnSaveCard.interactable = false;
        }
    }
    public void SetNull()
    {
        NameUpdateCard.text = "";
        errCheckNameCard.text = "";
    }
    public void SaveName(int id)
    {   
        if(id == 2)
        {
            int priceUser = PlayerPrefs.GetInt("UserPrice");
            if (priceUser < 99)
            {
                errCheckNameCard.text = "You don't have enough RP for the transaction";
            }
            if(priceUser > 99)
            {
                StartCoroutine(SaveNew(id));
            }
        }
        if(id == 1)
        {
            StartCoroutine(SaveNew(id));
        }
    }
    private IEnumerator SaveNew(int id)
    {
        string name = "";
        if (id == 1)
        {
            price = 0;
            name = NameUpdate.text.Trim();
        }
        if (id == 2)
        {
            price = 99;
            name = NameUpdateCard.text.Trim();
        }
        WWWForm form = new WWWForm();
        form.AddField("user_id", UserID);
        form.AddField("name", name);
        form.AddField("price", price);
        using (UnityWebRequest www = UnityWebRequest.Post($"{path}", form))
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
                    if(id == 2)
                    {
                        int UserPrice = PlayerPrefs.GetInt("UserPrice") - price;
                        PlayerPrefs.SetInt("UserPrice", UserPrice);
                        InfoUser.Instance.updatePrice(UserPrice);
                        CHPlay.Instance.updatePrice(UserPrice);

                        tableCard.SetActive(false);

                    }

                    yield return null;
                }
                else if (!account.status)
                {
                    yield return null;
                }
            }
        }
    }
    public void CheckName(int id)
    {
        Debug.Log(id + " da chay");
        StartCoroutine(CheckAPI(id));
    }
    private IEnumerator CheckAPI(int id)
    {
        string name = "";

        NameUpdate.interactable = false;
        NameUpdateCard.interactable = false;
        BtnCheck.interactable = false;
        BtnCheckCard.interactable = false;
        // update new
        if (id == 1)
        {
            name = NameUpdate.text.Trim();
        }
        // card name
        if (id == 2)
        {
            name = NameUpdateCard.text.Trim();
        }

        WWWForm form = new WWWForm();
        form.AddField("name", name);
        using (UnityWebRequest www = UnityWebRequest.Post($"{pathCheck}", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                GameAccounts account = JsonUtility.FromJson<GameAccounts>(www.downloadHandler.text);
                if (!account.status)
                {
                    errCheckName.text = "This name is already in use";
                    errCheckName.color = Color.red;
                    check = false;

                    errCheckNameCard.text = "This name is already in use";
                    errCheckNameCard.color = Color.red;
                    checkCard = false;
                }
                else
                {
                    errCheckName.text = "This name can use";
                    errCheckName.color = Color.blue;
                    check = true;

                    errCheckNameCard.text = "This name can use";
                    errCheckNameCard.color = Color.blue;
                    checkCard = true;


                    Nametemporary = name;
                }
            }
        }
        NameUpdate.interactable = true;
        NameUpdateCard.interactable = true;
        BtnCheck.interactable = true;
        BtnCheckCard.interactable = true;
    }
}
