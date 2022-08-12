using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUser : MonoBehaviour
{
    public DatabaseCharacter charactersDB;
    public SpriteRenderer Sprite;
    private Animator animator;
    private int selectedOption = 0;

    public DatabaseGameAccount DB;
    private int Points;

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
        updateCharacterNext();
    }

    
    void Update()
    {
        GameAccounts accounts = DB.GetGameAccounts(0);
        Points = accounts.points;
        charactersDB.CheckPoints(Points);
    }
    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= charactersDB.CharacterCount)
        {
            selectedOption = 0;
        }
        updateCharacterNext();
        save();
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = charactersDB.CharacterCount - 1;
        }
        updateCharacterBack();
        save();
    }
    public void updateCharacterBack()
    {
        Characters character = charactersDB.GetCharacter(selectedOption);
        if (character.Buy == false)
        {
            while (true)
            {
                selectedOption--;
                if (selectedOption < 0)
                {
                    selectedOption = charactersDB.CharacterCount - 1;
                }
                character = charactersDB.GetCharacter(selectedOption);
                if (character.Buy == true)
                {
                    break;
                }
            }
        }
        Sprite.sprite = character.CharacterSprite;
        animator.runtimeAnimatorController = character.animation as RuntimeAnimatorController;
        Sprite.drawMode = SpriteDrawMode.Sliced;
        Sprite.size = new Vector2(0.15f, 0.17f);
    }
    public void updateCharacterNext()
    {
        Characters character = charactersDB.GetCharacter(selectedOption);
        if (character.Buy  == false)
        {
            while (true)
            {
                selectedOption++;
                if (selectedOption >= charactersDB.CharacterCount)
                {
                    selectedOption = 0;
                }
                character = charactersDB.GetCharacter(selectedOption);
                if (character.Buy == true)
                {
                    break;
                }
            }
        }
        Sprite.sprite = character.CharacterSprite;
        animator.runtimeAnimatorController = character.animation as RuntimeAnimatorController;
        Sprite.drawMode = SpriteDrawMode.Sliced;
        Sprite.size = new Vector2(0.15f, 0.17f);
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