using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet4 : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    GameObject player;
    Vector2 moveDirection;
    public GameObject explosion;
    public float timeLoop, Speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        timeLoop -= Time.deltaTime;
        if(timeLoop <= 0)
        {
            player = GameObject.FindWithTag("Player");
            moveDirection = (player.transform.position - transform.position).normalized;
            rigidbody2D.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
            transform.right = new Vector2(moveDirection.x, moveDirection.y);
            timeLoop = 5;
        }
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
