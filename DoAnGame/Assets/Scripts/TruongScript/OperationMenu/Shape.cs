using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private Transform dino, dinoText1, dinoText2;
    [SerializeField] private float _cu = 0.5f;
    void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, 0.01f, 0), _cu).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
