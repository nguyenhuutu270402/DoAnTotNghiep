using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyNormal0 : MonoBehaviour
{
    public float HP;
    public Animator animator;
    bool die = false;
    public GameObject explosionClassic, explosionBazoka;
    public AILerp aILerp;


    // Start is called before the first frame update
    void Start()
    {
        int mode = PlayerPrefs.GetInt("ModeMap");

        if (mode == 0)
        {
        }
        else
        {
            HP = HP * 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            animator.SetBool("Die", true);
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
