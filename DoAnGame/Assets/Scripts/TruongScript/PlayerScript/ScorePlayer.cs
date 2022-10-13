using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScorePlayer : MonoBehaviour
{
    public TextMeshProUGUI TextScore;
    private int Score = 0;

    public static ScorePlayer Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        PlayerPrefs.SetInt("Score", 0);
    }
    void Start()
    {
        TextScore.text = Score + "";
    }

    
    public void IncreaseScore()
    {
        Score++;
        TextScore.text = Score + "";
        PlayerPrefs.SetInt("Score", Score);
    }


}
