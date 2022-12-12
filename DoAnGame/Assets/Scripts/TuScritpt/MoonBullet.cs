using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBullet : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigidbody2D;
    GameObject point;
    Vector2 moveDirection;
    public Animator animator;
    public GameObject explosionClassic, explosionBazoka;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);

        rigidbody2D = GetComponent<Rigidbody2D>();
        point = GameObject.FindWithTag("Point");
        moveDirection = (point.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody2D.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
        rigidbody2D.AddForce(new Vector2(moveDirection.x, moveDirection.y) * Speed);
        transform.up = new Vector2(moveDirection.x, moveDirection.y);
    }

    public void changeEnd()
    {
        animator.SetBool("End", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet_classic")
        {
            GameObject effect = Instantiate(explosionClassic, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bullet_bazooka" | collision.gameObject.tag == "bullet_miner")
        {
            GameObject effect = Instantiate(explosionBazoka, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "arrowforbow")
        {
            GameObject effect = Instantiate(explosionClassic, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(collision.gameObject);
        }

    }
}
