using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLoop = 5;
    public float timeRe;
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8, enemy9, enemy10, enemy11;
    public Animator animator;
    void Start()
    {

    }

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
            animator.SetBool("isWork", true);
        }

    }

    public void createEnemy()
    {
        int rd = Random.Range(1, 12);
        if (rd == 1)
        {
            Instantiate(enemy11, transform.position, Quaternion.identity);
        }
        else if(rd == 2)
        {
            Instantiate(enemy2, transform.position, Quaternion.identity);
        }
        else if(rd == 3)
        {
            Instantiate(enemy3, transform.position, Quaternion.identity);
        }
        else if(rd == 4)
        {
            Instantiate(enemy4, transform.position, Quaternion.identity);
        }
        else if(rd == 5)
        {
            Instantiate(enemy5, transform.position, Quaternion.identity);
        }
        else if(rd == 6)
        {
            Instantiate(enemy6, transform.position, Quaternion.identity);
        }
        else if(rd == 7)
        {
            Instantiate(enemy7, transform.position, Quaternion.identity);
        }
        else if(rd == 8)
        {
            Instantiate(enemy8, transform.position, Quaternion.identity);
        }
        else if(rd == 9)
        {
            Instantiate(enemy9, transform.position, Quaternion.identity);
        }
        else if(rd == 10)
        {
            Instantiate(enemy10, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy1, transform.position, Quaternion.identity);
        }


        timeLoop = timeRe;
        animator.SetBool("isWork", false);
    }
}
