using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAlpha3 : MonoBehaviour
{

    // Start is called before the first frame update
    public float timeRe, HP, SpeedBullet, SpeedRotation;
    float timeLoop;
    public GameObject enemyBullet;
    public GameObject explosionClassic, explosionBazoka;
    public Animator animator;
    bool die = false;
    float x, y, angel = 0, radius = 10;
    float xBullet, yBullet;

    public AILerp aILerp;
    public float timeResume;
    float timePause = 0;
    float timeResume_0;


    void Start()
    {
        int mode = PlayerPrefs.GetInt("ModeMap");
        timeResume_0 = timeResume;
        if (mode == 1)
        {
            // normal mode
            timeRe -= 0;
        }
        else
        {
            // hard mode
            timeRe -= 0.01f;
            HP = HP * 1.5f;

        }

        timeLoop = timeRe;
    }

    // Update is called once per frame
    void Update()
    {
        timeResume -= Time.deltaTime;
        if(timeResume <= 0)
        {
            attack();
            timePause += Time.deltaTime;    
        }
        if(timePause >= 3)
        {
            timeResume = timeResume_0;
            timePause = 0;
        }

        if (HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            animator.SetBool("Die", true);
            die = true;
        }
    }

    void attack()
    {
        angel = angel + Time.deltaTime * SpeedRotation;
        x = transform.position.x + Mathf.Cos(angel) * radius;
        y = transform.position.y + Mathf.Sin(angel) * radius;
        if (angel >= 360)
        {
            angel = 0;
        }


        timeLoop -= Time.deltaTime;
        if (timeLoop < 0 & die == false)
        {
            xBullet = x - transform.position.x;
            yBullet = y - transform.position.y;
            GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.velocity = new Vector2(xBullet * SpeedBullet, yBullet * SpeedBullet);
            bullet.transform.right = rbBullet.velocity;
            timeLoop = timeRe;
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
            HP -= 6;
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
