using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DatabaseGameAccount : ScriptableObject
{
    public GameAccounts[] gameAccounts = new GameAccounts[1];

    public int gameAccountsCount
    {
        get
        {
            return gameAccounts.Length;
        }
    }
    public GameAccounts GetGameAccounts(int index)
    {
        return gameAccounts[index];
    }

    public GameAccounts insertAccount(bool _status, string _id, string _name, int _price, int _points)
    {
        gameAccounts[0].status = _status;
        gameAccounts[0].id = _id;
        gameAccounts[0].name = _name;
        gameAccounts[0].price = _price;
        gameAccounts[0].points = _points;

        return gameAccounts[0];
    }
    public GameAccounts setName(string _name)
    {
        gameAccounts[0].name = _name;
        return gameAccounts[0];
    }
    public GameAccounts quitAccount()
    {
        gameAccounts[0].status = false;
        gameAccounts[0].id = "";
        gameAccounts[0].name = "";
        gameAccounts[0].price = 0;
        gameAccounts[0].points = 0;
        return gameAccounts[0];
    }

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
