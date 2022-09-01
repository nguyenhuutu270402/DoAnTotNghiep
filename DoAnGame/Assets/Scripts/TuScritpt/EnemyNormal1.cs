using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRe;
    float repeat, timeLoop;
    float repeatLoop;
    public GameObject myPrefab;

    //mode
    float mode = 1;
    void Start()
    {
        if (mode == 0)
        {
            repeat = 2; // normal mode
        }
        else
        {
            repeat = 3; // hard mode
        }
        repeatLoop = repeat;
        timeLoop = timeRe;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if(timeLoop <=0 )
        {
            if (repeatLoop > 0)
            {
                repeatLoop--;
                //GameObject bullet = Instantiate(myPrefab, transform.position, Quaternion.identity);
                Instantiate(myPrefab, transform.position, Quaternion.identity);
                timeLoop = 0.2f;

            } else
            {
                timeLoop = timeRe;
                repeatLoop = repeat;
            }
            
        }
    }

}
