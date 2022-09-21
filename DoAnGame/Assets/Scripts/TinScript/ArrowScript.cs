using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isStickAble = true;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            rb.velocity = Vector2.zero;
            isStickAble = false;
            
        }
        if (collision.gameObject.layer == 11 && isStickAble)
        {
            rb.isKinematic = true;
            this.transform.parent = collision.transform; 
        }



    }
}
