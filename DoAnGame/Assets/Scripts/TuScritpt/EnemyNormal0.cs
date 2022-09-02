using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal0 : MonoBehaviour
{
    public float HP;
    public Animator animator;
    bool die = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 & die == false)
        {
            animator.SetBool("Die", true);

        }
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
