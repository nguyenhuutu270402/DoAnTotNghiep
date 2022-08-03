using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameAccountDatabase : ScriptableObject
{
    public GameAccount[] gameAccounts = new GameAccount[1];

    public int gameAccountsCount
    {
        get
        {
            return gameAccounts.Length;
        }
    }
    public GameAccount GetGameAccounts(int index)
    {
        return gameAccounts[index];
    }

    public GameAccount insertAccount(string _status, string _statusName, string _id, string _name, int _price, int _points)
    {
        gameAccounts[0].status = _status;
        gameAccounts[0].statusName = _statusName;
        gameAccounts[0].id = _id;
        gameAccounts[0].name = _name;
        gameAccounts[0].price = _price;
        gameAccounts[0].points = _points;

        return gameAccounts[0];
    }
    public GameAccount setName(string _name)
    {
        gameAccounts[0].name = _name;
        return gameAccounts[0];
    }
}
