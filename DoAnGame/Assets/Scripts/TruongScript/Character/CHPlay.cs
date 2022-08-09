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
        Price.text = gameAccount.price + "  RP";
        MaxCharacter = charactersDB.CharacterCount;
        updateCharacter();
    }

    void Update()
    {
        if(selectedOption + 4 > MaxCharacter)
        {
            Next.interactable = false;
        }
        else
        {
            Next.interactable = true;
        }


        if(selectedOption - 3 < 0)
        {
            Back.interactable = false;
        }
        else
        {
            Back.interactable = true;
        }
        
        if(checkFrames[0] == 0)
        {
            LeanTween.rotateY(Character[0], 0f, 0.00001f);
        }
        if (checkFrames[1] == 0)
        {
            LeanTween.rotateY(Character[1], 0f, 0.00001f);
        }
        if (checkFrames[2] == 0)
        {
            LeanTween.rotateY(Character[2], 0f, 0.00001f);
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
                if (character.Buy == true || character.Price == 0)
                {
                    CharacterPrice[i].text = "";
                }
                else
                {
                    CharacterPrice[i].text = character.Price + " RP";
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
        // 0 1 2 tương ứng với stt từ trái trang phải
        float rotate = 0.3f;
        if (checkFrames[index] == 0)
        {
            LeanTween.rotateY(Character[index], 90f, rotate).setOnComplete(() =>
            {
                Frames[index].SetActive(false);
                CharacterProfile[index].SetActive(true);
                LeanTween.rotateY(Character[index], 180f, rotate);
            });
            checkFrames[index] = 1;
        }
        else if (checkFrames[index] == 1)
        {
            LeanTween.rotateY(Character[index], 270f, rotate).setOnComplete(() =>
            {
                Frames[index].SetActive(true);
                CharacterProfile[index].SetActive(false);
                LeanTween.rotateY(Character[index], 360f, rotate).setOnComplete(() =>
                {
                    checkFrames[index] = 0;
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
