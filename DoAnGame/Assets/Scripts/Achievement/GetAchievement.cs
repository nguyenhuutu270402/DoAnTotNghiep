using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class GetAchievement : MonoBehaviour
{
    private string ACHIEVEMENT_PATH = "http://localhost:3000/api/my-achievement/";
    private string USER_ID;
    public static GetAchievement Instance;

    public int point;
    //public List<achievement> achievements;
    //public achievement[] achievements;
    public achievementData _achievementData;
    private void Awake()
    {
        Instance = this;
        
    }
    private void Start()
    {
        point = PlayerPrefs.GetInt("UserPoints");
    }

    public void CheckGetData()
    {

        USER_ID = PlayerPrefs.GetString("UserID");
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{ACHIEVEMENT_PATH}{USER_ID}"))
        {
            yield return www.SendWebRequest();
            _achievementData = JsonUtility.FromJson<achievementData>(www.downloadHandler.text);
            foreach (var achievement in _achievementData.achievement)
            {
                Debug.Log(achievement.name + " name");
                Debug.Log(achievement.requiment + " requirement");
                Debug.Log(achievement.achieved + " achieved");
                Debug.Log("//////////////////");
            }
            Debug.Log( "PLAYER POINT: "+ point);

        }
    }

    private void Update()
    {
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
            achieved = true;
            Debug.Log($"{id}:{name} {description} {achieved} YOlO");
            
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
