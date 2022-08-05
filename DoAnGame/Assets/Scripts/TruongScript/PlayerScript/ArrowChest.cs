using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChest : MonoBehaviour
{
    public GameObject chest;
    int score;
    private int BossAppears = 0;
    public static ArrowChest Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if(BossAppears == 0)
        {
            transform.up = new Vector2(chest.transform.position.x - transform.position.x, chest.transform.position.y - transform.position.y);
        }
        else
        {
            Debug.Log("boss ne " + BossAppears);
            transform.gameObject.SetActive(false);
            chest.SetActive(false);
        }
    }
    public void Score(int _score)
    {
        score = _score;
        switch (score)
        {
            case 11: case 23: case 35: case 46: case 59: case 71: case 83: case 95: case 107: case 119: case 131:

                BossAppears = 1;

                break;
            default:

                BossAppears = 0;

                break;
        }
    }
}
