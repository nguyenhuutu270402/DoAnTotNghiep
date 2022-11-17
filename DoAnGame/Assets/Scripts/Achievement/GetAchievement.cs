using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetAchievement : MonoBehaviour
{
    private string ACHIEVEMENT_PATH = "http://localhost:3000/api/my-achievement/";
    private string USER_ID;
    public static GetAchievement Instance;

    public int point;
    public achievementData _achievementData;

    [SerializeField] private GameObject row;

    [SerializeField] private GameObject parentPanel;
    [SerializeField] private GameObject loadingText;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        point = PlayerPrefs.GetInt("UserPoints");
    }
    private void Start()
    {
        CheckGetData();
    }
    public void CheckGetData()
    {

        //USER_ID = PlayerPrefs.GetString("UserID"); //original player's id when run game
        USER_ID = "6373517f5646ccbf8b060e5b"; // hard player's id for test
        StartCoroutine(GetData());
        
    }

    private void SpawnAchievementList()
    {
        float rowHeight = 250; // one row height
        float posX = -700; // PosX Rect Transform in "RowContainer"
        float posY = -150; // PosY Rect Transform in "RowContainer"
        float panelLength = 0; // "RowContainer" height in Rect Transform
        float moveTime = 0.25f; 
        
        
        for (int i = 0; i < _achievementData.achievement.Length; i++)
        {
            GameObject _row = Instantiate(row, new Vector2(posX, posY), Quaternion.identity); // Create a row which contain all information of ONE achivement
            
            _row.transform.SetParent(parentPanel.transform, false); // Make it become children of parent panel
            _row.LeanMoveLocalX(0, moveTime); // Animation
            _row.transform.GetChild(0).GetComponent<Text>().text = _achievementData.achievement[i].name; // Get Text UI Component
            _row.transform.GetChild(1).GetComponent<Text>().text = _achievementData.achievement[i].description;
            _row.transform.GetChild(2).GetComponentInChildren<Text>().text = _achievementData.achievement[i].achieved == true ? "Claim" : "Incomplete";
            panelLength += rowHeight; // Increase "RowContainer" height so we can scroll it correctly
            parentPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(1100, panelLength); // Set "RowContainer" height
            posY -= rowHeight; // Position for next achievement in array
            moveTime += 0.1f; // The bottom row will be delayed a litle bit compared to the top row
        }
    }

    private void LoadingNotification()
    {
        if (_achievementData.achievement.Length <= 0)
        {
            loadingText.SetActive(true);
        }
        else if(_achievementData.achievement.Length > 0)
        {
            loadingText.SetActive(false);

        }
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{ACHIEVEMENT_PATH}{USER_ID}"))
        {
            yield return www.SendWebRequest();
            _achievementData = JsonUtility.FromJson<achievementData>(www.downloadHandler.text);
            foreach (var achievement in _achievementData.achievement)
            {
                //Debug.Log(achievement.name + " name");
                //.Log(achievement.requiment + " requirement");
            } // Got the data yet? Yes, wega them
            Debug.Log(point + "player point");
        }
        SpawnAchievementList();
    }

    private void Update()
    {
        LoadingNotification();
        CheckAchievementCompletion();
        
    }

    private void CheckAchievementCompletion()
    {
        //if (achievement == null)
        //    return;

        foreach (var achievement in _achievementData.achievement)
        {
            achievement.UpdateCompletion();
        }
    }


}

[Serializable]
public class achievementData
{
    public achievement[] achievement;
}

[Serializable]
public class achievement
{ 
    public string id;
    public string name;
    public int reward;
    public int requiment; // dieu kien hoan thanh (nhung no viet sai chinh ta)
    public string description;
    public bool achieved;

    public achievement(string id, string name, int reward, int requiment, string description, bool achieved)
    {
        this.id = id;
        this.name = name;
        this.reward = reward;
        this.requiment = requiment;
        this.description = description;
        this.achieved = achieved;
    }

    public void UpdateCompletion()
    {
        if (achieved)
            return;

        if (RequirementsMet())
        {
            Debug.Log($"{id}:{name} {description} {achieved} YOlO");
            achieved = true;
        }
    }
    public bool RequirementsMet()
    {
        bool checkRequirement = false;
        //return requiment.Invoke(null);
        if(GetAchievement.Instance.point >= requiment)
        {
            checkRequirement = true;
        }
        return checkRequirement;
    }
}
