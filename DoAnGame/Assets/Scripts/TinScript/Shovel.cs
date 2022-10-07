using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private float coolDown = 0;
    public float coolDownLap;

    private Animator animator;
    [SerializeField] public AudioSource[] triggerSound;
    public Transform circleOrigin;
    public float radius;

    private bool isDectect = false;




    void Start()
    {
        coolDown = coolDownLap;
        animator = GetComponent<Animator>();

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
        animator.SetBool("isSlash", false);
        isDectect = false;
    }
    void DoSlash()
    {

        triggerSound[0].Play();
        animator.SetBool("isSlash", true);
        isDectect = true;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectCollider()
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            
            if(collider.gameObject.layer == 11)
            {
                triggerSound[2].Play();
                Destroy(collider.gameObject);
            }
            if (collider.gameObject.layer == 8)
            {
                
               
            }
        }
    }

}
