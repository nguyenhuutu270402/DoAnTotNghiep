using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossbullet1 : MonoBehaviour
{
    public GameObject explosion;
    int touchNumber = 2;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hiable" || collision.gameObject.tag == "BlockBoder")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
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
