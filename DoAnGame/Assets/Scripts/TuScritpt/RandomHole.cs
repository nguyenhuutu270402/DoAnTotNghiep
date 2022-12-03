using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHole : MonoBehaviour
{
    public GameObject[] hole;
    float timeLoop = 5;
    float timeRe = 7;

    void Awake()
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

    void Update()
    {
        timeLoop -= Time.deltaTime;
        if (timeLoop < 0)
        {
            int rd = Random.Range(0, 2);
            int _rd = Random.Range(2, 4);

            Debug.Log(rd + " : " + _rd);

            hole[rd].GetComponent<BlackHole>().setCheck(true);
            hole[_rd].GetComponent<BlackHole>().setCheck(true);

            timeLoop = timeRe;
        }
    }
}
