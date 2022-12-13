using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private float coolDown = 0;
    public float coolDownLap;

    [SerializeField] private Animator animator;
    private AudioSource triggerSound;
    public Transform circleOrigin;
    public float radius;

    private bool isDectect = false;
    [SerializeField] private GameObject slashEffect1;    
    [SerializeField] private Transform rangeCircle;  
    [SerializeField] private GameObject player;
    [SerializeField] private float recoilForce;



    void Start()
    {
        coolDown = coolDownLap;
        triggerSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        coolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDown <= 0f && Time.timeScale != 0)
        {
            DoSlash();
            coolDown = coolDownLap;
        }
        if (isDectect == true)
        {
            DetectCollider();
        }
    }

    void DoSlash()
    {
        triggerSound.Play(); //play SFX
        animator.SetBool("isSlash", true);
        Instantiate(slashEffect1, rangeCircle.position, rangeCircle.rotation); // Genaration slash effect

        //Recoil
        player.GetComponent<Rigidbody2D>().AddForce(rangeCircle.right * -recoilForce, ForceMode2D.Force);

        isDectect = true;

        //CinemachineShake.Instance.ShakeCamera(1f, 0.1f);

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

            if (collider.gameObject.layer == 10)
            {
                Destroy(collider.gameObject);
            }
            if (collider.gameObject.layer == 8)
            {


            }
        }
    }
    public void ResetSlash()
    {
        animator.SetBool("isSlash", false);
        isDectect = false;
    }

}
