using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyNormal3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRe, HP, SpeedBullet;
    float repeat, timeLoop;
    float repeatLoop;
    public GameObject enemyBullet;
    public GameObject explosionClassic, explosionBazoka;

    public Animator animator;
    bool die = false;

    public AILerp aILerp;

    

    void Start()
    {
        int mode = PlayerPrefs.GetInt("ModeMap");

        if (mode == 0)
        {
            repeat = 1; // normal mode
        }
        else
        {
            repeat = 2; // hard mode
            HP = HP * 1.5f;
        }
        repeatLoop = repeat;
        timeLoop = timeRe;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        if (HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            die = true;
            animator.SetBool("Die", true);
        }
    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if (timeLoop <= 0)
        {
            if (repeatLoop > 0 & die == false)
            {
                repeatLoop--;
                Vector2 direction = aILerp.velocity;
                if (direction.x > 0)
                {
                    GameObject bullet1 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet1 = bullet1.GetComponent<Rigidbody2D>();
                    rbBullet1.velocity = new Vector2(2*SpeedBullet, 0 * SpeedBullet);
                    bullet1.transform.right = new  Vector2(2, 0);


                    GameObject bullet2 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet2 = bullet2.GetComponent<Rigidbody2D>();
                    rbBullet2.velocity = new Vector2(1 * SpeedBullet, 1 * SpeedBullet);
                    bullet2.transform.right = new Vector2(1, 1);


                    GameObject bullet3 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet3 = bullet3.GetComponent<Rigidbody2D>();
                    rbBullet3.velocity = new Vector2(1 * SpeedBullet, -1 * SpeedBullet);
                    bullet3.transform.right = new Vector2(1, -1);

                }
                else
                {
                    GameObject bullet1 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet1 = bullet1.GetComponent<Rigidbody2D>();
                    rbBullet1.velocity = new Vector2(-2 * SpeedBullet, 0 * SpeedBullet);
                    bullet1.transform.right = new Vector2(-2, 0);


                    GameObject bullet2 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet2 = bullet2.GetComponent<Rigidbody2D>();
                    rbBullet2.velocity = new Vector2(-1 * SpeedBullet, 1 * SpeedBullet);
                    bullet2.transform.right = new Vector2(-1, 1);


                    GameObject bullet3 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet3 = bullet3.GetComponent<Rigidbody2D>();
                    rbBullet3.velocity = new Vector2(-1 * SpeedBullet, -1 * SpeedBullet);
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
        if (collision.gameObject.tag == "bullet_classic")
        {
            HP -= 2;
            animator.SetBool("Hurt", true);
            GameObject effect = Instantiate(explosionClassic, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bullet_korth")
        {
            HP -= 4;
            animator.SetBool("Hurt", true);
            GameObject effect = Instantiate(explosionClassic, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bullet_sniper")
        {
            HP -= 18;
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
            HP -= 18;
            if (HP > 0)
            {
                animator.SetBool("Hurt", true);
            }
            Debug.Log("cham, ");
        }

        if (collision.gameObject.tag == "eplBazooka")
        {
            HP -= 12;
            animator.SetBool("Hurt", true);
        }
    }

}
