using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class BossTheThreeHusketeers : MonoBehaviour
{
    public float HP;
    public AILerp aILerp;
    //public GameObject enemyBullet;
    public GameObject explosionClassic, explosionBazoka, bullet1, bullet2;
    public GameObject effSkill1, effForMoonBullet, MoonBullet, pointForMoonBullet;
    public Animator animator;
    bool die = false;
    public float timeRe1;
    float timeLoop1;
    public float timeRe2;
    float timeLoop2;
    int skill1 = 0;
    int skill2 = 0;
    public int numberBullet2;
    int numBl2;

    // Start is called before the first frame update
    void Start()
    {
        timeLoop1 = timeRe1;
        timeLoop2 = timeRe2;
        numBl2 = numberBullet2;
    }

    // Update is called once per frame
    void Update()
    {
        attack1();
        attack2();
        if (HP <= 0 & die == false)
        {   
            aILerp.speed = 0;
            animator.SetBool("Die", true);
            die = true;
            ArrowChest.Instance.getPositionBoss(transform.position, true);
        }
    }

    void attack1()
    {
        timeLoop1 -= Time.deltaTime;
        if(timeLoop1 <= 0 & skill1 == 0 & die == false)
        {
            GameObject effectSkill1 = Instantiate(effSkill1, transform.position, Quaternion.identity);
            Instantiate(effForMoonBullet, transform.position, Quaternion.identity);
            Instantiate(pointForMoonBullet, transform.position, Quaternion.identity);

            Destroy(effectSkill1, 3);
            skill1 = 1;
            aILerp.speed = 0;
        }
        if(timeLoop1 <= -2)
        {
            Instantiate(MoonBullet, transform.position, Quaternion.identity);
            skill1 = 0;
            timeLoop1 = timeRe1;
            aILerp.speed = 0.3f;

        }
    }


    void attack2()
    {
        timeLoop2 -= Time.deltaTime;
        if (timeLoop2 <= 0 & skill2 == 0 & die == false)
        {
            float angel = 0, radius = 1, SpeedBall = 1.5f;

            for (int i = 0; i <= 20; i++)
            {
                float mx = transform.position.x + Mathf.Cos(angel) * radius;
                float my = transform.position.y + Mathf.Sin(angel) * radius;

                float xBall = mx - transform.position.x;
                float yBall = my - transform.position.y;

                GameObject bullet = Instantiate(bullet1, transform.position, Quaternion.identity);
                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
                rbBullet.velocity = new Vector2(xBall * SpeedBall, yBall * SpeedBall);
                bullet.transform.right = rbBullet.velocity;

                angel += 9;
            }

            skill2 = 1;

        }
        if (timeLoop2 <= 0f & die == false & numberBullet2 > 0)
        {
            Instantiate(bullet2, transform.position, Quaternion.identity);
            numberBullet2--;
            timeLoop2 = 0.15f;
        } else if (numberBullet2 <= 0)
        {
            numberBullet2 = numBl2;
            skill2 = 0;
            timeLoop2 = timeRe2;

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
