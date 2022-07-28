using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    float _cu = 0.3f;
    void Start()
    {
        transform.DOMoveY(-0.1f, _cu).OnStepComplete(() =>
        {
            transform.DOMoveY(0.02f, _cu * 1.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        });


    }


}
