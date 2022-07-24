using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public TextMeshProUGUI charactername;
    public SpriteRenderer artworkSprite;
    private Animator animator;

    private int selectedOption = 0;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        updateCharacter(selectedOption);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0; 
        }
        updateCharacter(selectedOption);
        save();
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        updateCharacter(selectedOption);
        save();
    }

    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprite;
        charactername.text = character.CharacterName;
        animator.runtimeAnimatorController = character.animation as RuntimeAnimatorController;
    }


    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
