using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AchievementManager : MonoBehaviour
{
    public static List<DinoAchievement> achievements;
    [Range(0, 100)]
    public int highScore; //for test
    [Range(0, 1000)]
    public int totalPoint; //for test
    private void Start()
    {
        InitializeAchievements();
    }

    public void InitializeAchievements()
    {
        if (achievements != null)
            return;

        achievements = new List<DinoAchievement>();

        achievements.Add(new DinoAchievement(GetArchiverment.Instance._achievement.open[0]._id,
            GetArchiverment.Instance._achievement.open[0].name,
            "First time get 12 weapon chest in game.",
            (object o) => highScore == 12));



        //achievements.Add(new DinoAchievement("achievement_id","First Blood", "First time get 12 weapon chest in game.", (object o) => highScore == 12));
        //achievements.Add(new DinoAchievement("achievement_id","Catch Up", "First time reach to 20 point.", (object o) => totalPoint == 20));
    }
    private void Update()
    {
        CheckAchievementCompletion();
    }

    private void CheckAchievementCompletion()
    {
        if (achievements == null)
            return;

        foreach (var achievement in achievements)
        {
            achievement.UpdateCompletion();
        }
    }


}

public class DinoAchievement
{

    public DinoAchievement(string id, string name, string description, Predicate<object> requirement)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.requirement = requirement;

    }

    public string id;
    public string name;
    public string description;
    public string user_id;
    public Predicate<object> requirement;

    public bool achieved;


    public void UpdateCompletion()
    {
        if (achieved)
            return;

        if (RequirementsMet())
        {
            Debug.Log($"{name}: {description}");
            achieved = true;
        }
    }

    public bool RequirementsMet()
    {
        return requirement.Invoke(null);
    }
}