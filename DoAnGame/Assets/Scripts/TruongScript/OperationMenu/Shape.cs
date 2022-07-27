using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private float _cu ;
    void Start()
    {
        transform.DOMoveY(-0.1f, _cu * 0.7f).OnStepComplete(() =>
        {
            transform.DOMoveY(0.02f, _cu).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        });

        //transform.DOScale(new Vector3(0, 0, 0), 0.3f).OnStepComplete(() =>
        //{
        //    Destroy(transform);
        //});
        //transform.DOScale(new Vector3(0, 0, 0), 0.5f).OnStepComplete(() =>
        //{
        //    gameObject.SetActive(false);
        //});

    }

    // Update is called once per frame
    void Update()
    {
    }
}
