using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossDarkSideDino : MonoBehaviour
{
    public float HP, timeRe, timeAttack1, timeAttack2, timeAttack3, SpeedBullet;
    public float numAttack1, numAttack2, numAttack3;
    bool die = false;
    float timeLoop, speedBoss, numAttack1Start, numAttack2Start, numAttack3Start;
    int attack = 0;
    public GameObject explosionClassic, explosionBazoka, bullet1, bullet2, bullet3, effFireRed, effFireYellow;
    public Animator animator;
    public AILerp aILerp;
    public GameObject[] weapons;
    public Transform[] pointFires;
    GameObject player;
    Vector2 moveDirection;

    // health bar script
    BossHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        int mode = PlayerPrefs.GetInt("ModeMap");

        if (mode == 1)
        {
            // normal mode
        }
        else
        {
            // hard mode
            HP = HP * 1.5f;
        }
        healthBar = FindObjectOfType<BossHealthBar>();
        healthBar.setMaxHealth(HP);
        healthBar.setBossName("DARKSIDE DINO");

        timeLoop = timeRe;
        speedBoss = aILerp.speed;
        numAttack1Start = numAttack1;
        numAttack2Start = numAttack2;
        numAttack3Start = numAttack3;
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(HP);
        if (HP <= 0 & die == false)
        {
            aILerp.speed = 0;
            animator.SetBool("Die", true);
            die = true;
            healthBar.setActiveBarBoss();
            ArrowChest.Instance.getPositionBoss(transform.position, true);
        }
        timeLoop -= Time.deltaTime;
        if(timeLoop <= 0 & attack == 0 & die == false)
        {
            aILerp.speed = 0f;
            // rd cac kieu xong setActive
            int rd = Random.Range(1, 4);
            attack = rd;
            setActiveWeapons(attack);
        }
        attack1();
        attack2();
        attack3();
    }


    void attack1()
    {
        if(timeLoop <= 0 & attack == 1 & die == false)
        {
            numAttack1--;
            moveDirection = (player.transform.position - transform.position).normalized;

            Instantiate(effFireRed, pointFires[0].position, Quaternion.identity);
            GameObject b = Instantiate(bullet1, pointFires[0].position, Quaternion.identity);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(moveDirection.x * SpeedBullet, moveDirection.y * SpeedBullet);
            b.transform.right = rb.velocity;
            b.transform.localScale = new Vector3(0.4f, 0.6f, 0.6f);
            timeLoop = timeAttack1;
            if(numAttack1 <= 0)
            {
                aILerp.speed = speedBoss;
                timeLoop = timeRe;
                attack = 0;
                numAttack1 = numAttack1Start;
            }
        }
    }

    void attack2()
    {
        if (timeLoop <= 0 & attack == 2 & die == false)
        {
            numAttack2--;
            moveDirection = (player.transform.position - transform.position).normalized;

            Instantiate(effFireYellow, pointFires[1].position, Quaternion.identity);
            GameObject b = Instantiate(bullet2, pointFires[1].position, Quaternion.identity);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(moveDirection.x * SpeedBullet, moveDirection.y * SpeedBullet);
            b.transform.right = rb.velocity;
            b.transform.localScale = new Vector3(0.4f, 0.6f, 0.6f);
            timeLoop = timeAttack2;
            if (numAttack2 <= 0)
            {
                aILerp.speed = speedBoss;
                timeLoop = timeRe;
                attack = 0;
                numAttack2 = numAttack2Start;
            }
        }
    }

    void attack3()
    {
        if (timeLoop <= 0 & attack == 3 & die == false)
        {
            numAttack3--;
            moveDirection = (player.transform.position - transform.position).normalized;

            Instantiate(effFireRed, pointFires[2].position, Quaternion.identity);
            GameObject b = Instantiate(bullet3, pointFires[2].position, Quaternion.identity);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(moveDirection.x * SpeedBullet, moveDirection.y * SpeedBullet);
            b.transform.right = rb.velocity;
            timeLoop = timeAttack3;
            if (numAttack3 <= 0)
            {
                aILerp.speed = speedBoss;
                timeLoop = timeRe;
                attack = 0;
                numAttack3 = numAttack3Start;
            }
        }
    }

    void setActiveWeapons(int attack)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == attack-1)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
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
