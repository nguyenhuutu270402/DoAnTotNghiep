using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLoop = 5;
    public float timeRe;
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8, enemy9, enemy10, enemy11, enemy12, enemy13, enemy14, enemy15, enemy16, enemy17;
    public GameObject[] gameObjects;
    public Animator animator;
    public bool check;


    void Start()
    {
        int mode = PlayerPrefs.GetInt("ModeMap");

        if (mode == 1)
        {
        }
        else
        {
            // hard mode
            timeRe -= timeRe / 3;
        }
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
        //Debug.Log(check + "  -setcheck + " + transform.name);
    }

    public void createEnemy()
    {
        //int rd = Random.Range(1, 18);
        //if (rd == 1)
        //{
        //    Instantiate(enemy11, transform.position, Quaternion.identity);
        //}
        //else if(rd == 2)
        //{
        //    Instantiate(enemy2, transform.position, Quaternion.identity);
        //}
        //else if(rd == 3)
        //{
        //    Instantiate(enemy3, transform.position, Quaternion.identity);
        //}
        //else if(rd == 4)
        //{
        //    Instantiate(enemy4, transform.position, Quaternion.identity);
        //}
        //else if(rd == 5)
        //{
        //    Instantiate(enemy5, transform.position, Quaternion.identity);
        //}
        //else if(rd == 6)
        //{
        //    Instantiate(enemy6, transform.position, Quaternion.identity);
        //}
        //else if(rd == 7)
        //{
        //    Instantiate(enemy7, transform.position, Quaternion.identity);
        //}
        //else if(rd == 8)
        //{
        //    Instantiate(enemy8, transform.position, Quaternion.identity);
        //}
        //else if(rd == 9)
        //{
        //    Instantiate(enemy9, transform.position, Quaternion.identity);
        //}
        //else if(rd == 10)
        //{
        //    Instantiate(enemy10, transform.position, Quaternion.identity);
        //}
        //else if (rd == 11)
        //{
        //    Instantiate(enemy12, transform.position, Quaternion.identity);
        //}
        //else if (rd == 12)
        //{
        //    Instantiate(enemy13, transform.position, Quaternion.identity);
        //}
        //else if (rd == 13)
        //{
        //    Instantiate(enemy14, transform.position, Quaternion.identity);
        //}
        //else if (rd == 14)
        //{
        //    Instantiate(enemy15, transform.position, Quaternion.identity);
        //}
        //else if (rd == 15)
        //{
        //    Instantiate(enemy16, transform.position, Quaternion.identity);
        //}
        //else if (rd == 16)
        //{
        //    Instantiate(enemy17, transform.position, Quaternion.identity);
        //}
        //else
        //{
        //    Instantiate(enemy1, transform.position, Quaternion.identity);
        //}
        int rd = Random.Range(0, gameObjects.Length - 1) ;
        Instantiate(gameObjects[rd], transform.position, Quaternion.identity);

        timeLoop = timeRe;
        animator.SetBool("isWork", false);
    }
}
