using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public DatabaseCharacter charactersDB;
    public SpriteRenderer artworkSprite;
    public int check;
    private Animator animator;
    private int selectedOption = 0;

    public DatabaseGameAccount data;
    private int index = 3;

    void Start()
    {
        GameAccounts gameAccount = data.GetGameAccounts(0);

        CheckIndex(gameAccount.points);

        animator = gameObject.GetComponent<Animator>();
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        if(check == 0) 
        {
            updateCharacter(0);
        } 
        else if(check == 1)
        {
            updateCharacter(selectedOption);
        }

    }
    public void CheckIndex(int _points)
    {   
        if(_points >= 100)
        {
            index = 4;
        }
        else if(_points >= 150)
        {
            index = 5;
        }
        else if (_points >= 200)
        {
            index = 6;
        }
    }
    public void NextOption()
    {
        int max = charactersDB.CharacterCount;
        if(check == 1)
        {
            max = index + 1;
        }

        selectedOption++;
        if(selectedOption >= max)
        {
            selectedOption = 0; 
        }
        updateCharacter(selectedOption);
        save();
    }
    public void BackOption()
    {
        int min = charactersDB.CharacterCount - 1;
        if (check == 1)
        {
            min = index;
        }

        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = min;
        }
        updateCharacter(selectedOption);
        save();
    }

    private void updateCharacter(int selectedOption)
    {
        Characters character = charactersDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprite;
        animator.runtimeAnimatorController = character.animation as RuntimeAnimatorController;
        artworkSprite.drawMode = SpriteDrawMode.Sliced;
        artworkSprite.size = new Vector2(0.15f, 0.17f);
    }
    


    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void save()
    {   if(selectedOption <= index && check == 1)
        {
            PlayerPrefs.SetInt("selectedOption", selectedOption);
        }
        
      
    }
}
