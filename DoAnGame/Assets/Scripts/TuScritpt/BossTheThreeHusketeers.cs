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
    public Animator animator;
    bool die = false;


    // Start is called before the first frame update
    void Start()
    {
        
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
