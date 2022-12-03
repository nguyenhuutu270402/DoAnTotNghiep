using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CHPlay : MonoBehaviour
{
    private int selectedOption = 0;
    private int MaxselectedOption;
    private int PointsUser;
    [Header("Data")]
    // list trnag phục tốn tiền
    public List<RuntimeAnimatorController> CharacterBuy = new List<RuntimeAnimatorController>();
    // list trang phuc cua user
    public List<RuntimeAnimatorController> PlayerUser = new List<RuntimeAnimatorController>();
    // list trang phuc cua user tính theo điểm
    public List<RuntimeAnimatorController> PlayerPoints = new List<RuntimeAnimatorController>();

    private List<RuntimeAnimatorController> characters;
    private List<int> prices;
    [Header("UserPrice")]
    public TextMeshProUGUI UserPrice;
    [Header("Btn")]
    public Button Back;
    public Button Next;
    public GameObject ImgBack;
    public GameObject ImgNext;
    [Header("character")]
    public Animator[] animator;
    public TextMeshProUGUI[] PriceText;
    public TextMeshProUGUI[] NameText;
    public TextMeshProUGUI[] IDText;
    public SpriteRenderer[] Sprite;
    public GameObject[] Frames;



    // thuộc buy item
    private int ID;
    [Header("Buy Item")]
    
    public TextMeshProUGUI TextConfirm;
    public GameObject Dino;
    public GameObject Confirm;
    public GameObject Erro;

    public static CHPlay Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        characters = new List<RuntimeAnimatorController>();
        characters.AddRange(PlayerUser);
        characters.AddRange(PlayerPoints);
        characters.AddRange(CharacterBuy);
        ListPrice();
        MaxselectedOption = characters.Count;
    }
    private void ListPrice()
    {
        prices = new List<int>();
        PointsUser = PlayerPrefs.GetInt("UserPoints");
        for (int i = 0; i < PlayerUser.Count; i++)
        {
            prices.Add(0);
        }
        for (int i = 0; i < PlayerPoints.Count; i++)
        {
            prices.Add(1);
        }
        prices.Add((int)PlayerPrefs.GetInt("arrPrice_1"));
        prices.Add((int)PlayerPrefs.GetInt("arrPrice_2"));
        int skin1 = PlayerPrefs.GetInt("skin1");
        int skin2 = PlayerPrefs.GetInt("skin2");
        if (skin1 == 8 || skin2 == 8)
        {
            prices[8] = 0;
        }
        if (skin1 == 7 || skin2 == 7)
        {
            prices[7] = 0;
        }
        if (PointsUser >= PlayerPrefs.GetInt("OpenCharacter_6"))
        {
            for (int i = 1; i < 7; i++)
            {
                prices[i] = 0;
            }
        }
        else if (PointsUser >= PlayerPrefs.GetInt("OpenCharacter_5"))
        {
            for (int i = 1; i < 6; i++)
            {
                prices[i] = 0;
            }
        }
        else if (PointsUser >= PlayerPrefs.GetInt("OpenCharacter_4"))
        {
            for (int i = 1; i < 5; i++)
            {
                prices[i] = 0;
            }
        }
        else if (PointsUser >= PlayerPrefs.GetInt("OpenCharacter_3"))
        {
            for (int i = 1; i < 4; i++)
            {
                prices[i] = 0;
            }
        }
        else if (PointsUser >= PlayerPrefs.GetInt("OpenCharacter_2"))
        {
            for (int i = 1; i < 3; i++)
            {
                prices[i] = 0;
            }
        }
        else if (PointsUser >= PlayerPrefs.GetInt("OpenCharacter_1"))
        {
            for(int i = 1; i < 2; i++)
            {
                prices[i] = 0;
            }
        }
    }
    public void UpdatePrice(int _id)
    {
        prices[_id] = 0;
    }

    void Start()
    {
        UserPrice.text = PlayerPrefs.GetInt("UserPrice") + "";
        updateCharacter();
    }
    public void updatePrice(int _price)
    {
        UserPrice.text = _price + "";
    }
    void Update()
    {
        if (selectedOption + 4 > MaxselectedOption)
        {
            Next.interactable = false;
            ImgNext.SetActive(false);

        }
        else
        {
            Next.interactable = true;
            ImgNext.SetActive(true);
        }


        if (selectedOption - 3 < 0)
        {
            Back.interactable = false;
            ImgBack.SetActive(false);
        }
        else
        {
            Back.interactable = true;
            ImgBack.SetActive(true);
        }
        updateCharacter();
    }
    public void NextOption()
    {
        selectedOption += 3;
        updateCharacter();
    }
    public void BackOption()
    {
        selectedOption -= 3;
        updateCharacter();
    }
    public void updateCharacter()
    {
        for (int i = 0; i < 3; i++)
        {
            int check = i + selectedOption;
            if(check < MaxselectedOption)
            {
                Frames[i].SetActive(true);
                NameText[i].text = characters[check].name;
                animator[i].runtimeAnimatorController = characters[check] as RuntimeAnimatorController;
                if(prices[check] == 0)
                {
                    PriceText[i].text = "Owned";
                    Sprite[i].color = new Color(1, 1, 1);
                }else if(prices[check] == 1)
                {
                    PriceText[i].text = "Owned't";
                    Sprite[i].color = new Color(0.01f, 0.01f, 0.01f);
                }
                else
                {
                    PriceText[i].text = prices[check] + " coin";
                    Sprite[i].color = new Color(0.01f, 0.01f, 0.01f);
                }
                IDText[i].text = check + "";
            }
            else
            {
                Frames[i].SetActive(true);
            }
            
        }
    }
    public void BuyItemID(int _id)
    {
        ID = int.Parse(IDText[_id].text.Trim());
        if (prices[ID] > 1)
        {
            Debug.Log(ID + " có thể mua");
            Confirm.SetActive(true);
            Dino.SetActive(false);
            Erro.SetActive(false);
            TextConfirm.text = "You definitely want to use " + prices[ID] + " coin to buy a " + characters[ID].name;
            BuyItemWeb.Instance.BuyItem(ID, prices[ID]);
        }
        else
        {
            Debug.Log(ID + " đã mua");
        }
    }
}
