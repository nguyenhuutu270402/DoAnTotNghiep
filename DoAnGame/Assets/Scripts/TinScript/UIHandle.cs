using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandle : MonoBehaviour
{
    const string achievementSceneName = "Achievement";
    const string menuSceneName = "Menu";


    public void BackToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
    public void AchieveScene()
    {
        SceneManager.LoadScene(achievementSceneName);
    }
    
}