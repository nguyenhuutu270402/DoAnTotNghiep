using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUmbrellaDarkKnight : MonoBehaviour
{
    public float timeRe, numBullet, speed, SpeedBullet;
    float timeLoop;
    GameObject player;
    Vector2 moveDirection;
    bool isAttack = false;
    public Animator animator;
    public float HP;
    public GameObject explosionClassic, explosionBazoka, bullet, umbrella1, umbrella2, shadow, expAttack, explosionDead, pointBossMove;
    public Rigidbody2D rb2D;
    bool die = false;
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
            //HP += (HP / 2);
            HP *= 2;
        }
        healthBar = FindObjectOfType<BossHealthBar>();
        healthBar.setMaxHealth(HP);
        healthBar.setBossName("UMBRELLA DARK KNIGHT");
        timeLoop = timeRe;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(HP);

        attack();
        if (HP <= 0 & die == false)
        {
            animator.SetBool("Die", true);
            die = true;
            healthBar.setActiveBarBoss();
            ArrowChest.Instance.getPositionBoss(transform.position, true);
        }
    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if (timeLoop <= 0 & isAttack == false & die == false)
        {
            animator.SetBool("Attack1", true);
            player = GameObject.FindWithTag("Player");
            moveDirection = (player.transform.position - transform.position).normalized;
            Instantiate(pointBossMove, player.transform.position, Quaternion.identity);
            isAttack = true;
            // an cay du 1 hien cay du 2
            umbrella1.gameObject.SetActive(false);
            umbrella2.gameObject.SetActive(true);

        }
    }

    void attack2()
    {
        Instantiate(expAttack, transform.position, Quaternion.identity);
        for(int i = 0; i < numBullet; i++)
        {
            float xBullet = Random.Range(-0.1f, 0.1f);
            float yBullet = Random.Range(-0.1f, 0.1f);
            GameObject bullet0 = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet0.GetComponent<Rigidbody2D>();
            rbBullet.velocity = new Vector2(xBullet * SpeedBullet, yBullet * SpeedBullet);
            bullet0.transform.right = new Vector2(xBullet * SpeedBullet, yBullet * SpeedBullet);
        }
        transform.up = new Vector2(0, 1);
        rb2D.velocity = new Vector2(0, 0);
        animator.SetBool("Attack1", false);
        animator.SetBool("Attack2", false);
        isAttack = false;
        timeLoop = timeRe;
        // an cay du 2 hien cay du 1 va shadow
        umbrella2.gameObject.SetActive(false);
        umbrella1.gameObject.SetActive(true);
        shadow.gameObject.SetActive(true);

    }

    public void changeAttack()
    {
        // an cay du 1, cay du 2, shadow
        umbrella2.gameObject.SetActive(false);
        umbrella1.gameObject.SetActive(false);
        shadow.gameObject.SetActive(false);

        animator.SetBool("Attack2", true);
        transform.up = new Vector2(moveDirection.x, moveDirection.y);
        rb2D.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

    }

    public void changeAnimatorNormal()
    {
        animator.SetBool("Hurt", false);
    }

    public void deadEnemy()
    {
        Destroy(gameObject);
        GameObject expls = Instantiate(explosionDead, transform.position, Quaternion.identity);
        Destroy(expls, 0.25f);
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
        if(collision.gameObject.tag == "PointBossMove")
        {
            attack2();
            Destroy(collision.gameObject);
        }
    }
}
