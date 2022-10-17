using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossGiantMutantBeetle : MonoBehaviour
{
    public float HP, timeRe, timeReBullet, SpeedBullet, numBullet;
    bool die = false, isRun = false, isAttack = false;
    float timeLoop, speedBoss, HPStart, numBulletStart, rdX, rdY;
    public Transform pointBullet;
    public GameObject explosionClassic, explosionBazoka, bullet1, bullet2, prison, effPrison, effPrison2;
    public Animator animator;
    public AILerp aILerp;
    GameObject player;
    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        timeLoop = timeRe;
        speedBoss = aILerp.speed;
        aILerp.speed = 0;
        HPStart = HP;
        numBulletStart = numBullet;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            animator.SetBool("Die", true);
            die = true;
        }
        timeLoop -= Time.deltaTime;
        if(timeLoop <= 0 & isAttack == false & die == false)
        {
            isAttack = true;
            attack1();
        }
        attack2();
    }

    void attack1()
    {
        if(isRun == true)
        {
            Instantiate(bullet1, pointBullet.position, Quaternion.identity);
        }
    }

    void attack2()
    {
        if (isAttack == true & timeLoop <= 0)
        {
            numBullet--;
            moveDirection = (player.transform.position - transform.position).normalized;
            if (moveDirection.x > 0 )
            {
                rdX = Random.Range(0.001f, moveDirection.x);
            } else
            {
                rdX = Random.Range(moveDirection.x, 0.001f);
            }

            if (moveDirection.y < 0)
            {
                rdY = Random.Range(0.001f, moveDirection.y);
            }
            else
            {
                rdY = Random.Range(moveDirection.y, 0.001f);
            }

            GameObject b = Instantiate(bullet2, pointBullet.position, Quaternion.identity);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rdX * SpeedBullet, rdY * SpeedBullet);
            b.transform.right = rb.velocity;

            timeLoop = timeReBullet;
            if (numBullet <= 0)
            {
                Instantiate(bullet1, pointBullet.position, Quaternion.identity);
                timeLoop = timeRe;
                isAttack = false;
                numBullet = numBulletStart;
            }
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

        if(HP <= (HPStart / 2) & isRun == false)
        {
            isRun = true;
            aILerp.speed = speedBoss;
            // destroy prison, tao eff pha huy prison
            Destroy(prison);
            GameObject eff = Instantiate(effPrison, transform.position, Quaternion.identity);
            GameObject eff2 = Instantiate(effPrison2, transform.position, Quaternion.identity);
            Destroy(eff2, 0.25f);
            Destroy(eff, 2f);
        }
    }

}
