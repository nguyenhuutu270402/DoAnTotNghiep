using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CHPlay : MonoBehaviour
{
    public DatabaseCharacter charactersDB;
    public DatabaseGameAccount data;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI[] CharacterName;
    public GameObject[] Character;
    public SpriteRenderer[] Sprite;
    public Animator[] animator;
    public TextMeshProUGUI[] CharacterPrice;
    public Button Next, Back;

    private int selectedOption = 0;
    private int MaxCharacter; 

    void Start()
    {
        GameAccounts gameAccount = data.GetGameAccounts(0);
        Price.text = gameAccount.price + "  RP";
        MaxCharacter = charactersDB.CharacterCount;
        updateCharacter();
    }

    void Update()
    {
        if(selectedOption + 3 > MaxCharacter)
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
        Debug.Log("có cc: " + selectedOption);
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
    private void updateCharacter()
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
                if (character.Price == 0)
                {
                    CharacterPrice[i].text = "";
                }
                else
                {
                    CharacterPrice[i].text = character.Price + " RP";
                }
            }
            else
            {
                Character[i].SetActive(false);
            }
        }
        
    }
}
