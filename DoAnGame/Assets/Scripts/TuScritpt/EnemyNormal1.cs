using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRe, HP;
    float repeat, timeLoop;
    float repeatLoop;
    public GameObject enemyBullet;
    public Animator animator;
    bool die = false;

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
            animator.SetBool("Die", true);
        }
    }

    void attack()
    {
        timeLoop -= Time.deltaTime;
        if(timeLoop <=0 )
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
        // cham dan chuyen animation
        if(collision.gameObject.tag == "bullet_classic")
        {
            HP -= 1;
            animator.SetBool("Hurt", true);
        }
    }

    

    

}
