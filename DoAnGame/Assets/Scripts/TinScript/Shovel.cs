using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private float coolDown = 0;
    public float coolDownLap;

    private Animator animator; 
    private AudioSource triggerSound;
    public Transform circleOrigin;
    public float radius;

    private bool isDectect = false;
    public Collider2D collider2D;



    void Start()
    {
        coolDown = coolDownLap;
        animator = GetComponent<Animator>();
        triggerSound = GetComponent<AudioSource>();
        //collider2D = GetComponent<Collider2D>();

    }
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDown <= 0f && Time.timeScale != 0)
        {
            DoSlash();
            coolDown = coolDownLap;
        }
        if(isDectect == true)
        {
            DetectCollider();
        }
    }


    public void ResetSlash()
    {
        collider2D.enabled = false;
        animator.SetBool("isSlash", false);
        isDectect = false;
    }
    void DoSlash()
    {
        collider2D.enabled = true;
        triggerSound.Play();
        animator.SetBool("isSlash", true);
        isDectect = true;
        CinemachineShake.Instance.ShakeCamera(1f, 0.1f);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectCollider()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            
            if(collider.gameObject.layer == 10 )
            {
                Destroy(collider.gameObject);
            }
            if (collider.gameObject.layer == 8)
            {
                
               
            }
        }
    }

}
