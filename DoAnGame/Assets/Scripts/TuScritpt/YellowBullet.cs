using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBullet : MonoBehaviour
{
    // Start is called before the first frame update
    int touchNumber = 2;
    public GameObject explosion;
    GameObject player;
    Rigidbody2D rigidbody2D;
    public float Speed;
    Vector2 moveDirection;

    void Start()
    {
        Destroy(gameObject, 3.5f);
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized;


        rigidbody2D.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
            touchNumber--;
            if (touchNumber <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
    }

}
