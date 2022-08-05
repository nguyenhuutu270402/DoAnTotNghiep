using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterPlayer : MonoBehaviour
{
    public DatabaseCharacter charactersDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        selectedOption = PlayerPrefs.GetInt("selectedOption");
        updateCharacter(selectedOption);
    }
    private void updateCharacter(int selectedOption)
    {
        Characters character = charactersDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprite;
        animator.runtimeAnimatorController = character.animation as RuntimeAnimatorController;
        artworkSprite.drawMode = SpriteDrawMode.Sliced;
        artworkSprite.size = new Vector2(0.15f, 0.17f);
    }

}
