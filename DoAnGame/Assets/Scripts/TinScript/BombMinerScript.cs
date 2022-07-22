using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMinerScript : MonoBehaviour
{
    public float fieldOfImpact;
    public float force;

    public LayerMask LayerToHit;
    public GameObject ExplosionEffect;


    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            explosion();
            gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            Destroy(gameObject, audioSource.clip.length);
        }
        else
        {
            //Destroy(gameObject, 3f);
        }
    }
    public void explosion()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);
        foreach (Collider2D obj in objects)
        {
            audioSource.Play();
            if (obj.gameObject.tag == "Enemies")
            {
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
                Destroy(obj.gameObject, 1f);
            }
            else
            {
                return;
            }
            GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}
