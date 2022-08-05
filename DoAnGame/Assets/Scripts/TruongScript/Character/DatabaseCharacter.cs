using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class DatabaseCharacter : ScriptableObject
{
    public Characters[] character;


    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }
    public Characters GetCharacter(int index)
    {
        return character[index];
    }
}


[System.Serializable]

public class Characters
{
    public string CharacterName;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController animation;
}