using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class BossSkullGod : MonoBehaviour
{
    public float HP, timeRe;
    public AILerp aILerp;
    public GameObject explosionClassic, explosionBazoka, bullet1, bullet2;
    public Animator animator;
    bool die = false, isAttack = false;
    float timeLoop;
    public GameObject enemySkull;
    public Transform point1, point2, point3, point4;

    // Start is called before the first frame update
    void Start()
    {
        timeLoop = timeRe;
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
            attack2();
        }
    }


    void attack1()
    {
        Instantiate(enemySkull, point1.position, Quaternion.identity);
        Instantiate(enemySkull, point2.position, Quaternion.identity);
        Instantiate(enemySkull, point3.position, Quaternion.identity);
        Instantiate(enemySkull, point4.position, Quaternion.identity);
        timeLoop = timeRe;
        isAttack = false;
    }

    void attack2()
    {
        
    }

    void attack3()
    {

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
