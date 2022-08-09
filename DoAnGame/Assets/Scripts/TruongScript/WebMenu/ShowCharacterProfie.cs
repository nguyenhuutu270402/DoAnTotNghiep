using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCharacterProfie : MonoBehaviour
{
    public GameObject character;
    public GameObject Frames;
    public GameObject Profile;
    public TextMeshProUGUI IDText;
    private int check = 0;

    public static ShowCharacterProfie Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void ClickShow()
    {
        float rotate = 0.5f;
        if (check == 0)
        {
            LeanTween.rotateY(character, 90f, rotate).setOnComplete(() =>
            {
                Frames.SetActive(false);
                Profile.SetActive(true);
                LeanTween.rotateY(character, 180f, rotate);
            });
            check = 1;
        }else if(check == 1)
        {
            LeanTween.rotateY(character, 270f, rotate).setOnComplete(() =>
            {
                Frames.SetActive(true);
                Profile.SetActive(false);
                LeanTween.rotateY(character, 360f, rotate);
            });
            check = 0;
        }
    }
    public void Reset()
    {
        LeanTween.rotateY(character, 360f, 0.001f);
        Frames.SetActive(true);
        Profile.SetActive(false);
        check = 0;
    }
}
