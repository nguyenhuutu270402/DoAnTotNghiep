using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal6 : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float Speed;
    float x, y;
    public float timeRe, HP;
    Animator animator;

    float repeat, timeLoop;
    float repeatLoop;
    public GameObject enemyBullet, explosion;
    public GameObject explosionClassic, explosionBazoka;

    bool die = false;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        x = Random.Range(0f, 1f) == 0 ? -1 : 1;
        y = Random.Range(0f, 1f) == 0 ? -1 : 1;
        rigidbody2D.velocity = new Vector2(x * Speed, y * Speed);

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
        if (rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }

        if (rigidbody2D.velocity.x < Speed - 0.2f & rigidbody2D.velocity.x > -Speed + 0.2f)
        {
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
            rigidbody2D.velocity = new Vector2(x * Speed, y * Speed);

        }

        attack();
        if (HP <= 0 & die == false)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
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
                Vector2 direction = rigidbody2D.velocity;
                if (direction.x > 0)
                {
                    GameObject bullet1 = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    Rigidbody2D rbBullet1 = bullet1.GetComponent<Rigidbody2D>();
                    rbBullet1.velocity = new Vector2(2, 0);
                    bullet1.transform.right = new Vector2(2, 0);


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
                timeLoop = 0.4f;

            }
            else
            {
                timeLoop = timeRe;
                repeatLoop = repeat;
            }

        }
    }

    public void deadEnemy()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void changeAnimatorNormal()
    {
        animator.SetBool("Hurt", false);
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
        if (collision.gameObject.tag == "Melee")
        {
            HP -= 8;
            animator.SetBool("Hurt", true);
        }
    }


}
