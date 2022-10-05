using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class BossRandom : MonoBehaviour
{
    public List<GameObject> Positionboss = new List<GameObject>();
    public List<GameObject> bosss = new List<GameObject>();
    public GameObject PositionBoss;
    private int LengthChild_PositionBoss = 0;

    private int PreviousPosition; // hi?n t?i
    private int CurrentPosition = -1;  // tr??c ?ó

    private int PreviousBoss; // hi?n t?i
    private int CurrentBoss = -1;  // tr??c ?ó

    public GameObject Depot; // n?i ch?a boss

    public static BossRandom Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LengthChild_PositionBoss = PositionBoss.transform.childCount;
        for (int i = 0; i < LengthChild_PositionBoss; i++)
        {
            Positionboss.Add(PositionBoss.transform.GetChild(i).gameObject);
        }
    }



    public void RandomBossAndPosition()
    {
        CurrentPosition = PreviousPosition;
        PreviousPosition = Random.Range(0, Positionboss.Count - 1);
        while (CurrentPosition == PreviousPosition)
        {
            PreviousPosition = Random.Range(0, Positionboss.Count - 1);
        }
        Vector3 position = Positionboss[PreviousPosition].transform.position;

        CurrentBoss = PreviousBoss;
        PreviousBoss = Random.Range(0, bosss.Count - 1);
        while (CurrentBoss == PreviousBoss)
        {
            PreviousBoss = Random.Range(0, bosss.Count - 1);
        }
        GameObject boss = Instantiate(bosss[PreviousBoss], position, Quaternion.identity);
        boss.transform.parent = Depot.transform;

    }

}
