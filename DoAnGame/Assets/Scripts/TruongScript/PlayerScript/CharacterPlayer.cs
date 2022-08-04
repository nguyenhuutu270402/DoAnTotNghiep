using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterPlayer : MonoBehaviour
{
    // truong
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    private Animator animator;
    //
    void Start()
    {
        animator = GetComponent<Animator>();
        // truong
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        updateCharacter(selectedOption);

        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log(scene.buildIndex + "   map");

        //
    }


    void Update()
    {
        
    }
    // truong
    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprite;
        animator.runtimeAnimatorController = character.animation as RuntimeAnimatorController;
        artworkSprite.drawMode = SpriteDrawMode.Sliced;
        artworkSprite.size = new Vector2(0.15f, 0.17f);


    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
