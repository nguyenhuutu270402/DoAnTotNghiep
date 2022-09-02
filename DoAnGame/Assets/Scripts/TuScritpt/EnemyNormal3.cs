using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyNormal3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRe, HP;
    float repeat, timeLoop;
    float repeatLoop;
    public GameObject enemyBullet;
    public Animator animator;
    bool die = false;

    AILerp EnemyAIPath;

    //mode
    float mode = 1;
    void Start()
    {
        if (mode == 0)
        {
            repeat = 1; // normal mode
        }
        else
        {
            repeat = 2; // hard mode
        }
        repeatLoop = repeat;
        timeLoop = timeRe;
        EnemyAIPath = GetComponent<AILerp>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        if (HP <= 0 & die == false)
        {
            animator.SetBool("Die", true);
        }
    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if (timeLoop <= 0)
        {
            if (repeatLoop > 0)
            {
                repeatLoop--;
                Vector2 direction = EnemyAIPath.velocity;
                if (direction.x > 0)
                {
                    GameObject bullet1 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet1 = bullet1.GetComponent<Rigidbody2D>();
                    rbBullet1.velocity = new Vector2(2, 0);
                    bullet1.transform.right = new  Vector2(2, 0);


                    GameObject bullet2 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet2 = bullet2.GetComponent<Rigidbody2D>();
                    rbBullet2.velocity = new Vector2(1, 1);
                    bullet2.transform.right = new Vector2(1, 1);


                    GameObject bullet3 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet3 = bullet3.GetComponent<Rigidbody2D>();
                    rbBullet3.velocity = new Vector2(1, -1);
                    bullet3.transform.right = new Vector2(1, -1);

                }
                else
                {
                    GameObject bullet1 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet1 = bullet1.GetComponent<Rigidbody2D>();
                    rbBullet1.velocity = new Vector2(-2, 0);
                    bullet1.transform.right = new Vector2(-2, 0);


                    GameObject bullet2 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet2 = bullet2.GetComponent<Rigidbody2D>();
                    rbBullet2.velocity = new Vector2(-1, 1);
                    bullet2.transform.right = new Vector2(-1, 1);


                    GameObject bullet3 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet3 = bullet3.GetComponent<Rigidbody2D>();
                    rbBullet3.velocity = new Vector2(-1, -1);
                    bullet3.transform.right = new Vector2(-1, -1);

                }
                timeLoop = 0.3f;

            }
            else
            {
                timeLoop = timeRe;
                repeatLoop = repeat;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // cham dan chuyen animation
        if (collision.gameObject.tag == "bullet_classic")
        {
            HP -= 1;
            animator.SetBool("Hurt", true);
        }
    }
}
