using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet3 : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    GameObject player;
    Vector2 moveDirection;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);

        player = GameObject.FindWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        //rigidbody2D.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
        transform.right = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hiable" || collision.gameObject.tag == "BlockBoder")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
