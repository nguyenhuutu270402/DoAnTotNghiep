using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public TextMeshProUGUI charactername;
    public SpriteRenderer artworkSprite;
    public int check;



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
        if(check == 0) { } 
        else if(check == 1)
        {
            updateCharacter(selectedOption);
        }
        
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

        artworkSprite.drawMode = SpriteDrawMode.Sliced;
        artworkSprite.size = new Vector2(0.15f, 0.17f);
    }


    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void save()
    {   
        if(check == 0) { }
        else if(check == 1)
        {
            PlayerPrefs.SetInt("selectedOption", selectedOption);
        }
      
    }
}
