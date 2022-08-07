using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndQuit : MonoBehaviour
{
    float _cu = 0.3f;
    public GameObject dino;
    public DatabaseGameAccount data;
    public DatabaseCharacter character;
    void Start()
    {
        LeanTween.moveY(dino, 0.5f, _cu).setOnComplete(() =>
        {
            LeanTween.moveY(dino, 0.02f, _cu * 3f).setLoopPingPong();
        });
    }
    public void quit()
    {
        Application.Quit();
        data.quitAccount();
        character.reset();
    }
}
