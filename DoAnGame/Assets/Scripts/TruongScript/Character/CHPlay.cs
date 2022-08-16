using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CHPlay : MonoBehaviour
{   

    [Header("Data")]
    public DatabaseCharacter charactersDB;
    public DatabaseGameAccount data;
    [Header("Button")]
    public Button Next;
    public Button Back;
    public GameObject next;
    public GameObject back;
    [Header("UserPrice")]
    public TextMeshProUGUI Price;
    [Header("FrameCharacter")]
    public TextMeshProUGUI[] CharacterName;
    public SpriteRenderer[] Sprite;
    public Animator[] animator;
    public TextMeshProUGUI[] CharacterPrice;
    public TextMeshProUGUI[] ID;
    public TextMeshProUGUI[] Profile;
    [Header("Frame")]
    public GameObject[] Character;
    public GameObject[] Frames;
    public GameObject[] CharacterProfile;
    public Button[] btnClick;
    
    [Header("FrameIndex")]
    public TextMeshProUGUI[] FrameIndex;

    private int selectedOption = 0;
    private int MaxCharacter;

  
    public int[] checkFrames;


    public static CHPlay Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameAccounts gameAccount = data.GetGameAccounts(0);
        Price.text = gameAccount.price + "";
        MaxCharacter = charactersDB.CharacterCount;
        updateCharacter();
    }

    void Update()
    {

        if (selectedOption + 4 > MaxCharacter)
        {
            Next.interactable = false;
            next.SetActive(false);
            
        }
        else
        {
            Next.interactable = true;
            next.SetActive(true);
        }


        if(selectedOption - 3 < 0)
        {
            Back.interactable = false;
            back.SetActive(false);
        }
        else
        {
            Back.interactable = true;
            back.SetActive(true);
        }

        CheckUpdate();
    }
    public void CheckUpdate()
    {
        for (int i = 0; i < 3; i++)
        {
            LeanTween.rotateY(Character[i], 0f, 0.00001f);
            LeanTween.rotateY(CharacterProfile[i], 0, 0.00001f);
        }

    }

    public void NextOption()
    {
        selectedOption += 3;
        updateCharacter();
        ResetProfile();
    }
    public void BackOption()
    {
        selectedOption -= 3;
        updateCharacter();
        ResetProfile();
    }
    public void updateCharacter()
    {
        for (int i = 0; i < 3; i++)
        {
            int check = i + selectedOption;
            if(check < MaxCharacter)
            {
                Character[i].SetActive(true);
                Characters character = charactersDB.GetCharacter(check);
                CharacterName[i].text = character.CharacterName + "";
                Sprite[i].sprite = character.CharacterSprite;
                Sprite[i].drawMode = SpriteDrawMode.Sliced;
                Sprite[i].size = new Vector2(0.15f, 0.17f);
                animator[i].runtimeAnimatorController = character.animation as RuntimeAnimatorController;
                if (character.Buy == true )
                {
                    CharacterPrice[i].text = "Have owned";
                    Sprite[i].color = new Color(1, 1, 1);
                }
                else if(character.Price == 1)
                {
                    CharacterPrice[i].text = "Owned't";
                    Sprite[i].color = new Color(0.01f, 0.01f, 0.01f);
                }
                else
                {
                    CharacterPrice[i].text = character.Price + " RP";
                    Sprite[i].color = new Color(0.01f, 0.01f, 0.01f);
                }
                ID[i].text = check + "";
                Profile[i].text = character.Profile;
            }
            else
            {
                Character[i].SetActive(false);
            }
        }
    }
    public void ClickShow(int index)
    {
        btnClick[index].interactable = false;
        // 0 1 2 tương ứng với stt từ trái trang phải
        float rotate = 0.3f;
        if (checkFrames[index] == 0)
        {
            LeanTween.rotateY(Character[index], 90f, rotate).setOnComplete(() =>
            {
                FrameIndex[index].text = "2/2";
                checkFrames[index] = 1;
                Frames[index].SetActive(false);
                CharacterProfile[index].SetActive(true);
                LeanTween.rotateY(Character[index], 180f, rotate).setOnComplete(() =>
                {
                    btnClick[index].interactable = true;
                });
            });
        }
        else if (checkFrames[index] == 1)
        {
            LeanTween.rotateY(Character[index], 270f, rotate).setOnComplete(() =>
            {
                FrameIndex[index].text = "1/2";
                checkFrames[index] = 0;
                CharacterProfile[index].SetActive(false);
                Frames[index].SetActive(true);
                LeanTween.rotateY(Character[index], 360f, rotate).setOnComplete(() =>
                {
                    btnClick[index].interactable = true;
                });
            });
        }
    }
    public void ResetProfile()
    {
        for (int i = 0; i < 3; i++)
        {
            LeanTween.rotateY(Character[i], 0f, 0.00001f);
            Frames[i].SetActive(true);
            CharacterProfile[i].SetActive(false);
            checkFrames[i] = 0;
        }
    }
}
