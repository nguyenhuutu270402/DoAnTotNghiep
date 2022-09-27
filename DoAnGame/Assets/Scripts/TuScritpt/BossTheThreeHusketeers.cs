using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class BossTheThreeHusketeers : MonoBehaviour
{
    public float HP;
    public AILerp aILerp;
    //public GameObject enemyBullet;
    public GameObject explosionClassic, explosionBazoka;
    public GameObject effSkill1, effForMoonBullet, MoonBullet, pointForMoonBullet;
    public Animator animator;
    bool die = false;
    public float timeRe;
    float timeLoop;
    int skill1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeLoop = timeRe;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        if (HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            animator.SetBool("Die", true);
            die = true;
        }
    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if(timeLoop <= 0 & skill1 == 0 & die == false)
        {
            GameObject effectSkill1 = Instantiate(effSkill1, transform.position, Quaternion.identity);
            Instantiate(effForMoonBullet, transform.position, Quaternion.identity);
            Instantiate(pointForMoonBullet, transform.position, Quaternion.identity);

            Destroy(effectSkill1, 3);
            skill1 = 1;
            aILerp.speed = 0;
        }
        if(timeLoop <= -3)
        {
            Instantiate(MoonBullet, transform.position, Quaternion.identity);
            skill1 = 0;
            timeLoop = timeRe;
            aILerp.speed = 0.3f;

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
