using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    public GameObject bullet, eff;
    GameObject player;
    Vector2 moveDirection;
    public float timeRe, numBullet, timeRe2;
    float timeLoop, numBullet0;
    public Transform tfFirepoint;





    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        timeLoop = timeRe;
        numBullet0 = numBullet;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        moveDirection = (player.transform.position - transform.position).normalized;
        transform.right = new Vector2(moveDirection.x, moveDirection.y);

    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if (timeLoop <= 0)
        {


            if (numBullet0 <= 0)
            {
                timeLoop = timeRe;
                numBullet0 = numBullet;
            }
            else
            {
                float sp = 0.2f;
                for (int i = 0; i < 5; i++)
                {
                    sp += 0.13f;
                    GameObject bl = Instantiate(bullet, tfFirepoint.position, Quaternion.identity);
                    Rigidbody2D rbBl = bl.GetComponent<Rigidbody2D>();
                    Vector2 dir = new Vector2((moveDirection.x * sp) + moveDirection.x, (moveDirection.y * sp) + moveDirection.y);
                    rbBl.velocity = dir;
                    //Debug.Log("i day ne : " + sp);
                }
                numBullet0--;
                Instantiate(eff, tfFirepoint.position, Quaternion.identity);
                timeLoop = timeRe2;
            }
        }


    }
}
