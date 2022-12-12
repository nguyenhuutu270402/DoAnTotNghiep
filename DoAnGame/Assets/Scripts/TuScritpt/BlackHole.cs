using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLoop = 5;
    public float timeRe;
    public GameObject[] gameObjects;
    public Animator animator;
    public bool check;
    public GameObject DepotEnemy;

    // Update is called once per frame
    void Update()
    {
        rdEnemy();
    }

    void rdEnemy()
    {
        timeLoop -= Time.deltaTime;
        if (timeLoop < 0)
        {
            if(check)
            {
                animator.SetBool("isWork", true);
                check = false;
            }
        }

    }

    public void setCheck(bool _check)
    {
        check = _check;
    }

    public void createEnemy()
    {
        int rd = Random.Range(0, gameObjects.Length) ;
        GameObject Enemy = Instantiate(gameObjects[rd], transform.position, Quaternion.identity);

        Enemy.transform.parent = DepotEnemy.transform;



        timeLoop = timeRe;
        animator.SetBool("isWork", false);
    }
}
