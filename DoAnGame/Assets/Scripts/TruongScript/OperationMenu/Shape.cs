using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    float _cu = 0.3f;
    public GameObject dino;
    void Start()
    {
        LeanTween.moveY(dino, 0.5f, _cu).setOnComplete(() =>
        {
            LeanTween.moveY(dino, 0.02f, _cu * 3f).setLoopPingPong();
        });

    }


}
