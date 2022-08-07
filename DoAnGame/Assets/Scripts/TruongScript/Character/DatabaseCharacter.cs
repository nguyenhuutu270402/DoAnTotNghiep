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
    public Characters reset()
    {
        for (int i = 4; i < CharacterCount; i++)
        {
            character[i].Buy = false;
        }

        return null;
    }
    public Characters BuyID(int id)
    {
        character[id].Buy = true;
        return null;
    }
    public Characters CheckPoints(int _points)
    {
        if(_points >= 200)
        {
            character[4].Buy = true;
            character[5].Buy = true;
            character[6].Buy = true;
        }
        else if(_points >= 150)
        {
            character[4].Buy = true;
            character[5].Buy = true;
        }else if(_points >= 100)
        {
            character[4].Buy = true;
        }

        return null;
    }
}


[System.Serializable]

public class Characters
{
    public int _id;
    public string CharacterName;
    public Sprite CharacterSprite;
    public RuntimeAnimatorController animation;
    public int Price;
    public bool Buy;
}