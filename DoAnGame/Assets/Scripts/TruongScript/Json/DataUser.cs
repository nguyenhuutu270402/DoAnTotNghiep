using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUser : MonoBehaviour
{
}

[System.Serializable]
public class GameAccounts
{
    public bool status;
    public string id;
    public string name;
    public int price;
    public int points;
}

[System.Serializable]
public class GameAccountCharacter
{
    public List<int> listID = new List<int>();
}

