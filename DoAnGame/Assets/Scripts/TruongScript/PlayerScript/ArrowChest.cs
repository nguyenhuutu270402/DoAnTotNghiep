using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowChest : MonoBehaviour
{
    public GameObject chest;
    public GameObject Depot;
    public GameObject ChestBoss;
    private int score;
    private int BossAppears = 0;
    private Vector3 positionChestBoss;
    private bool checkDie = false;
    private bool checkChest = false;
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
            chest.SetActive(false);
            if (checkChest)
            {
                transform.up = new Vector2(Depot.transform.GetChild(0).transform.position.x - transform.position.x, Depot.transform.GetChild(0).transform.position.y - transform.position.y);
            }
            else
            {
                if (Depot.transform.childCount > 0)
                {
                    transform.up = new Vector2(Depot.transform.GetChild(0).transform.position.x - transform.position.x, Depot.transform.GetChild(0).transform.position.y - transform.position.y);
                }
            }
        }
        if (checkDie)
        {
            GameObject Chest_ = Instantiate(ChestBoss, positionChestBoss, Quaternion.identity);
            Chest_.name = "chest_Boss_0";
            Chest_.transform.parent = Depot.transform;
            checkDie = false;
            checkChest = true;
        }
    }
    public void setactive()
    {
        chest.SetActive(true);
    }
    public void Score(int _score)
    {
        score = _score;
        switch (score)
        {
            case 11: case 23: case 35: case 46: case 59: case 71: case 83: case 95: case 107: case 119: case 131:

                BossAppears = 1;
                BossRandom.Instance.RandomBossAndPosition();
                
                break;
            default:

                BossAppears = 0;

                break;
        }
    }
    public void getPositionBoss(Vector3 v, bool _checkDie)
    {
        positionChestBoss = v;
        checkDie = _checkDie;
    }
}
