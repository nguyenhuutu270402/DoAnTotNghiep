using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestRandom : MonoBehaviour
{
    public List<GameObject> chests = new List<GameObject>();
    public GameObject PositionChest;
    private int LengthChild_PositionChest = 0;
    private int PreviousPosition; // hiện tại
    private int CurrentPosition = -1;  // trước đó
    public static ChestRandom Instance { get; private set; }

    public TextMeshProUGUI UIScore;
    private int Score = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        LengthChild_PositionChest = PositionChest.transform.childCount;
        for(int i = 0; i < LengthChild_PositionChest; i++)
        {
            chests.Add(PositionChest.transform.GetChild(i).gameObject);
        }
    }


    public void RandomPosition()
    {
        CurrentPosition = PreviousPosition;
        PreviousPosition = Random.Range(0, chests.Count - 1);
        while (CurrentPosition == PreviousPosition)
        {
            PreviousPosition = Random.Range(0, chests.Count - 1);
        }
        transform.position = chests[PreviousPosition].transform.position;
        Score++;
        UIScore.text = Score + "";
        ArrowChest.Instance.Score(Score);
    }
    
}
