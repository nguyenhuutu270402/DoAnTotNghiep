using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class BossSkullGod : MonoBehaviour
{
    public float HP, timeRe, SpeedBullet, SpeedRotation, timeAttack2, numAttack2, timeAttack3, numAttack3, timeAttack4, numAttack4;
    public AILerp aILerp;
    public GameObject explosionClassic, explosionBazoka, bullet1, bullet2, effBuffHP;
    public Animator animator;
    bool die = false;
    float timeLoop;
    public GameObject enemySkull;
    public Transform point1, point2, point3, point4;
    float x, y, angel = 0, radius = 10;
    float xBullet, yBullet;
    float nAttack2, nAttack3, nAttack4, attack = 0, speedBoss;


    // Start is called before the first frame update
    void Start()
    {
        timeLoop = timeRe;
        nAttack2 = numAttack2;
        nAttack3 = numAttack3;
        nAttack4 = numAttack4;
        speedBoss = aILerp.speed;
    }

    // Update is called once per frame
    void Update()
    {


        if (HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            animator.SetBool("Die", true);
            die = true;
            ArrowChest.Instance.getPositionBoss(transform.position, true);
        }


        timeLoop -= Time.deltaTime;
        if (timeLoop <= 0 & attack == 0 & die == false)
        {
            int rd = Random.Range(1, 5);
            if (rd == 1)
            {
                attack = 1;
            }
            else if (rd == 2)
            {
                attack = 2;
                numAttack2 = nAttack2;
            }
            else if (rd == 3)
            {
                attack = 3;
                numAttack3 = nAttack3;
            }
            else
            {
                attack = 4;
                GameObject eff = Instantiate(effBuffHP, transform.position, Quaternion.identity);
                Destroy(eff, 2.5f);
                numAttack4 = nAttack4;
                timeLoop = timeAttack4;
            }

            
        }




        if (attack == 1)
        {
            attack1();
        }
        if (attack == 2)
        {
            attack2();
        }
        if (attack == 3)
        {
            attack3();
        }
        if (attack == 4)
        {
            attack4();
        }
    }


    void attack1()
    {
        Instantiate(enemySkull, point1.position, Quaternion.identity);
        Instantiate(enemySkull, point2.position, Quaternion.identity);
        Instantiate(enemySkull, point3.position, Quaternion.identity);
        Instantiate(enemySkull, point4.position, Quaternion.identity);
        timeLoop = timeRe;
        attack = 0;
    }

    void attack2()
    {
        angel = angel + Time.deltaTime * SpeedRotation;
        x = transform.position.x + Mathf.Cos(angel) * radius;
        y = transform.position.y + Mathf.Sin(angel) * radius;
        if (angel >= 360)
        {
            angel = 0;
        }


        timeLoop -= Time.deltaTime;
        if (timeLoop <= 0)
        {
            numAttack2--;

            xBullet = x - transform.position.x;
            yBullet = y - transform.position.y;
            GameObject bullet = Instantiate(bullet1, transform.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.velocity = new Vector2(xBullet * SpeedBullet, yBullet * SpeedBullet);
            bullet.transform.right = rbBullet.velocity;

            GameObject bullet2 = Instantiate(bullet1, transform.position, Quaternion.identity);
            Rigidbody2D rbBullet2 = bullet2.GetComponent<Rigidbody2D>();
            rbBullet2.velocity = new Vector2(xBullet * -SpeedBullet, yBullet * -SpeedBullet);
            bullet2.transform.right = rbBullet2.velocity;
            timeLoop = timeAttack2;
        }
        if (numAttack2 <= 0)
        {
            attack = 0;
            timeLoop = timeRe;
        }
    }

    void attack3()
    {
        timeLoop -= Time.deltaTime;
        if (timeLoop <= 0)
        {
            numAttack3--;

            GameObject b1 = Instantiate(bullet2, point1.position, Quaternion.identity);
            Rigidbody2D rb1 = b1.GetComponent<Rigidbody2D>();
            rb1.velocity = new Vector2(0, 2);
            b1.transform.right = rb1.velocity;

            GameObject b2 = Instantiate(bullet2, point2.position, Quaternion.identity);
            Rigidbody2D rb2 = b2.GetComponent<Rigidbody2D>();
            rb2.velocity = new Vector2(0, -2);
            b2.transform.right = rb2.velocity;

            GameObject b3 = Instantiate(bullet2, point3.position, Quaternion.identity);
            Rigidbody2D rb3 = b3.GetComponent<Rigidbody2D>();
            rb3.velocity = new Vector2(2, 0);
            b3.transform.right = rb3.velocity;

            GameObject b4 = Instantiate(bullet2, point4.position, Quaternion.identity);
            Rigidbody2D rb4 = b4.GetComponent<Rigidbody2D>();
            rb4.velocity = new Vector2(-2, 0);
            b4.transform.right = rb4.velocity;

            timeLoop = timeAttack3;
        }
        if (numAttack3 <= 0)
        {
            attack = 0;
            timeLoop = timeRe;
        }
    }

    void attack4()
    {

        aILerp.speed = 0;
        timeLoop -= Time.deltaTime;



        if (timeLoop <= 0)
        {
            numAttack4--;
            HP += 10;
            timeLoop = timeAttack4;
            if (HP > 100)
            {
                HP = 100;
            }
        }
        if (numAttack4 <= 0)
        {
            aILerp.speed = speedBoss;
            attack = 0;
            timeLoop = timeRe;
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet_classic")
        {
            HP -= 1;
            animator.SetBool("Hurt", true);
            GameObject effect = Instantiate(explosionClassic, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bullet_bazooka" | collision.gameObject.tag == "bullet_miner")
        {
            animator.SetBool("Hurt", true);
            GameObject effect = Instantiate(explosionBazoka, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "arrowforbow")
        {
            HP -= 1;
            if (HP > 0)
            {
                animator.SetBool("Hurt", true);
            }
        }

        if (collision.gameObject.tag == "eplBazooka")
        {
            HP -= 10;
            animator.SetBool("Hurt", true);
        }
    }
}
