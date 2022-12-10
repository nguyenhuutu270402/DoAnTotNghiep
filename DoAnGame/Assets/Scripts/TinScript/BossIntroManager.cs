using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntroManager : MonoBehaviour
{
    [SerializeField] private GameObject bossName;
    [SerializeField] private GameObject background1;
    [SerializeField] private GameObject background2;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject attachment;
    
    void Start()
    {

    }


            

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Invoke("MoveOutXPos", 0.8f);



            MoveInXPos(bossName, 0, 0.5f);
            MoveInXPos(background1, 0, 0.4f);
            MoveInXPos(background2, 0, 0.4f);
            MoveInXPos(main, 0, 0.2f);
            MoveInXPos(attachment, 0, 0.4f);
        }
    }

    void MoveOutXPos()
    {
        bossName.LeanMoveLocalX(1920, 0.5f);
        background1.LeanMoveLocalX(-1920, 0.5f);
        background2.LeanMoveLocalX(1920, 0.5f);
        main.LeanMoveLocalX(-1920, 0.5f);
        attachment.LeanMoveLocalX(1920, 0.5f);
    }

    void MoveInXPos(GameObject gameObject, int pos, float time)
    {
        gameObject.LeanMoveLocalX(pos, time);
    }
}
