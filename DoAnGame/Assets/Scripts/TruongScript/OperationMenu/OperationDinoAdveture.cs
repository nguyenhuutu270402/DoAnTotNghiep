using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OperationDinoAdveture : MonoBehaviour
{
    float _cu = 0.4f;
    void Start()
    {
        transform.DOMoveX(5f, _cu).OnStepComplete(() =>
        {
            transform.DOMoveY(0.2f, _cu).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        });
    }

}
