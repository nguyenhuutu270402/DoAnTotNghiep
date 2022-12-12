using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigidbody2D;
    GameObject player;
    Vector2 moveDirection;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.5f);

        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        rigidbody2D.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
        transform.right = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
