using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlpha1 : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float Speed;
    float x, y;
    public float HP;
    Animator animator;

    public GameObject explosion;
    bool die = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        x = Random.Range(0f, 1f) == 0 ? -1 : 1;
        y = Random.Range(0f, 1f) == 0 ? -1 : 1;
        rigidbody2D.velocity = new Vector2(x * Speed, y * Speed);

        int mode = PlayerPrefs.GetInt("ModeMap");

        if (mode == 1)
        {
            Speed += 0;
        }
        else
        {
            Speed += 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);

        }

        if (rigidbody2D.velocity.x < Speed - 0.2f & rigidbody2D.velocity.x > -Speed + 0.2f)
        {
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
            rigidbody2D.velocity = new Vector2(x * Speed, y * Speed);

        }

        if (HP <= 0 & die == false)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            animator.SetBool("Die", true);
        }
    }


    public void deadEnemy()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void changeAnimatorNormal()
    {
        animator.SetBool("Hurt", false);
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
