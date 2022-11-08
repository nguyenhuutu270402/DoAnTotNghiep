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
    public string image;
}

[System.Serializable]
public class GameAccountPoint
{
    public int[] point;
}

[System.Serializable]
public class GameAccountCharacter
{
    public int[] data;
}
[System.Serializable]
public class GameAccountOpen
{
    public int[] open;
}
[System.Serializable]
public class GameAccountArrPriceCharacter
{
    public int[] arrPrice;
}
