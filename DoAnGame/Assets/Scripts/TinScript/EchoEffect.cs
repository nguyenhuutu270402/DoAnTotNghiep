using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    private float startTimeBtwSpawns;

    public GameObject echo;

    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            //spawn dust
            GameObject dust = Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(dust, 0.6f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
       
    }
}
