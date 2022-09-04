using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndQuit : MonoBehaviour
{
    float _cu = 0.3f;
    public GameObject dino;
    public DatabaseCharacter character;
    void Start()
    {
        LeanTween.moveY(dino, 0.3f, _cu).setOnComplete(() =>
        {
            LeanTween.moveY(dino, 0.02f, _cu * 3f).setLoopPingPong();
        });
    }
    public void quit()
    {
        Application.Quit();
        character.reset();
    }
}
