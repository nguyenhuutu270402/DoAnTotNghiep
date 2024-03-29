using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyNormal1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRe, HP;
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
            repeat = 2; // normal mode
        }
        else
        {
            repeat = 3; // hard mode
            HP = HP * 1.5f;

        }
        repeatLoop = repeat;
        timeLoop = timeRe;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        if(HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            die = true;
            animator.SetBool("Die", true);
        }
    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if(timeLoop <=0 & die == false)
        {
            if (repeatLoop > 0)
            {
                repeatLoop--;
                //GameObject bullet = Instantiate(myPrefab, transform.position, Quaternion.identity);
                Instantiate(enemyBullet, transform.position, Quaternion.identity);
                timeLoop = 0.2f;

            } else
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
