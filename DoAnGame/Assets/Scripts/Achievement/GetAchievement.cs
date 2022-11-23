using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetAchievement : MonoBehaviour
{
    private string ACHIEVEMENT_PATH = "http://localhost:3000/api/my-achievement/";
    private string ACHIEVEMENT_UPDATE_PATH = "http://localhost:3000/api/my-achievement/update";
    private string ACHIEVEMENT_REWARD_PATH = "http://localhost:3000/api/add-price";
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
            //Destroy(gameObject);
            //return;
        }

        Instance = this;
        point = PlayerPrefs.GetInt("UserPoints");
        
    }
    private void Start()
    {
        USER_ID = PlayerPrefs.GetString("UserID"); //original player's id when run game

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
            var temp = i; // cho này cu ao ao, chac chan phai xem lai(Unity3D: Best way to add listener programmatically for Button onClick // Github)

            GameObject _row = Instantiate(row, new Vector2(posX, posY), Quaternion.identity); // Create a row which contain all information of ONE achivement
            _row.transform.SetParent(parentPanel.transform, false); // Make it become children of parent panel
            _row.LeanMoveLocalX(0, moveTime); // Animation
            _row.transform.GetChild(0).GetComponent<Text>().text = _achievementData.achievement[i].name; // Get Text UI Component
            _row.transform.GetChild(1).GetComponent<Text>().text = _achievementData.achievement[i].description;
            _row.transform.GetChild(2).GetComponentInChildren<Text>().text
                = _achievementData.achievement[i].achieved == true ? "Claim" : "Incomplete";

            Button claimButton = _row.transform.GetChild(2).GetComponent<Button>();
            claimButton.onClick.AddListener(delegate {
                OnClickClaimButton(
                _achievementData.achievement[temp].reward,
                _achievementData.achievement[temp].id,
                _achievementData.achievement[temp].achieved,
                _achievementData.achievement[temp].rewarded,
                claimButton);
                
            });


            panelLength += rowHeight; // Increase "RowContainer" height so we can scroll it correctly
            parentPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(1100, panelLength); // Set "RowContainer" height
            posY -= rowHeight; // Position for next achievement in array
            moveTime += 0.1f; // The bottom row will be delayed a litle bit compared to the top row
        }
    }

    public void OnClickClaimButton(int i, string id, bool achieved, bool rewarded, Button button)
    {
        if (rewarded )
        {
            Debug.Log("Tham nam, ban da nhan thuong cua thanh tuu nay roi");
            return;
        }

        if (!rewarded && achieved) // dat du yeu cau + chua nhan
        {
            Debug.Log("U received " + i + " coin");
            StartCoroutine(SendCoin(i));
            rewarded = true;
            StartCoroutine(SetAchievement(id, achieved+"", rewarded+""));
            button.enabled = false;
            //StartCoroutine(GetData());
        }
        if (!rewarded && !achieved)
        {
            Debug.Log("Ra xa hoi lam an buong chai de nhan " + i + " coin nhe");

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


    public IEnumerator GetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"{ACHIEVEMENT_PATH}{USER_ID}"))
        {
            yield return www.SendWebRequest();
            _achievementData = JsonUtility.FromJson<achievementData>(www.downloadHandler.text);
            foreach (var achievement in _achievementData.achievement)
            {
                //Debug.Log(achievement.name + " name");
                //Debug.Log(achievement.id + " id");
                //Debug.Log(achievement.requiment + " requirement");
                //Debug.Log(achievement.reward + " reward");
                //Debug.Log(achievement.rewarded + " rewarded");
                //Debug.Log(achievement.achieved + " achieved");
                //Debug.Log(achievement.description + " description");
            } // Got the data yet? Yes, wega them
            Debug.Log(point + "player point");
        }
        CheckAchievementCompletion();
        SpawnAchievementList();

    }

    public IEnumerator SetAchievement(string id, string achieved, string rewarded)
    {
        WWWForm form = new WWWForm();
        form.AddField("_id", id);
        form.AddField("achieved", achieved.ToString().ToLower());
        form.AddField("rewarded", rewarded.ToString().ToLower());

        using (UnityWebRequest www = UnityWebRequest.Post($"{ACHIEVEMENT_UPDATE_PATH}", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            yield return null;
        }
    }
    public IEnumerator SendCoin(int number)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_id", USER_ID);
        form.AddField("price", number);
        using (UnityWebRequest www = UnityWebRequest.Post($"{ACHIEVEMENT_REWARD_PATH}", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            yield return null;
        }
    }



    private void Update()
    {
        LoadingNotification();
    }

    private void CheckAchievementCompletion()
    {
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
    public bool rewarded;

    public achievement(string id, string name, int reward, int requiment, string description, bool achieved, bool rewarded)
    {
        this.id = id;
        this.name = name;
        this.reward = reward;
        this.requiment = requiment;
        this.description = description;
        this.achieved = achieved;
        this.rewarded = rewarded;
    }

    public void UpdateCompletion()
    {
        if (achieved)
            return;

        if (RequirementsMet())
        {
            achieved = true;
            GetAchievement.Instance.StartCoroutine(GetAchievement.Instance.SetAchievement(id, achieved + "", rewarded + ""));
        }
    }
    public bool RequirementsMet()
    {
        bool checkRequirement = false;
        if(GetAchievement.Instance.point >= requiment)
        {
            checkRequirement = true;
        }
        return checkRequirement;
    }

   
}
