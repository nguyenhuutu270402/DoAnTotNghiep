using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            loadNextLevel();
        }
    }

    public void loadNextLevel()
    {
        StartCoroutine(Loadlever(0));
    }

    IEnumerator Loadlever(int leverIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(leverIndex);
    }
}
