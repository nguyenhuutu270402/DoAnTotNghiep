using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLoop = 5;
    public float timeRe;
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8, enemy9, enemy10, enemy11;
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
            int rd = Random.Range(1, 10);
            if(rd == 1)
            {
                Instantiate(enemy1, transform.position, Quaternion.identity);
            }
            if (rd == 2)
            {
                Instantiate(enemy2, transform.position, Quaternion.identity);
            }
            if (rd == 3)
            {
                Instantiate(enemy3, transform.position, Quaternion.identity);
            }
            if (rd == 4)
            {
                Instantiate(enemy4, transform.position, Quaternion.identity);
            }
            if (rd == 5)
            {
                Instantiate(enemy5, transform.position, Quaternion.identity);
            }
            if (rd == 6)
            {
                Instantiate(enemy6, transform.position, Quaternion.identity);
            }
            if (rd == 7)
            {
                Instantiate(enemy7, transform.position, Quaternion.identity);
            }
            if (rd == 8)
            {
                Instantiate(enemy8, transform.position, Quaternion.identity);
            }
            if (rd == 9)
            {
                Instantiate(enemy9, transform.position, Quaternion.identity);
            }
            if (rd == 10)
            {
                Instantiate(enemy10, transform.position, Quaternion.identity);
            }
            if (rd == 11)
            {
                Instantiate(enemy11, transform.position, Quaternion.identity);
            }


            timeLoop = timeRe;
        }
            
    }
}
