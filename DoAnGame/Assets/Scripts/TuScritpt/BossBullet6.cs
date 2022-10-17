using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet6 : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    GameObject player;
    Vector2 moveDirection;
    public GameObject explosion, bullet;
    public float Speed, numBullet, SpeedBullet;


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
        rigidbody2D.AddForce(new Vector2(moveDirection.x, moveDirection.y) * Speed);
        transform.right = new Vector2(moveDirection.x, moveDirection.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hiable" || collision.gameObject.tag == "BlockBoder")
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            expl.transform.localScale = new Vector3(3f, 3f, 3f);
            Destroy(gameObject);
            for(int i = 0; i < numBullet; i++)
            {
                float rdX = Random.Range(-0.1f, 0.1f);
                float rdY = Random.Range(-0.1f, 0.1f);

                GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
                Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rdX*SpeedBullet, rdY*SpeedBullet);
                b.transform.right = rb.velocity;
            }
        }
    }
}
