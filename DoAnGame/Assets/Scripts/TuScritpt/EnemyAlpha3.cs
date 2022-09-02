using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlpha3 : MonoBehaviour
{

    // Start is called before the first frame update
    public float timeRe, HP, SpeedBullet, SpeedRotation;
    float timeLoop;
    public GameObject enemyBullet;
    public Animator animator;
    bool die = false;
    float x, y, angel = 0, radius = 10;
    float xBullet, yBullet;


    void Start()
    {
        int mode = PlayerPrefs.GetInt("ModeMap");

        if (mode == 1)
        {
            // normal mode
            timeRe -= 0;
        }
        else
        {
            // hard mode
            timeRe -= 0.01f;
        }

        timeLoop = timeRe;
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        if (HP <= 0 & die == false)
        {
            animator.SetBool("Die", true);
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
        if (timeLoop < 0)
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
        // cham dan chuyen animation
        if (collision.gameObject.tag == "bullet_classic")
        {
            HP -= 1;
            animator.SetBool("Hurt", true);
        }
    }

}
