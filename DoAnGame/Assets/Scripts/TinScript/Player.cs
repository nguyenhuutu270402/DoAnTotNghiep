using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 moveDelta;
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;

    private Animator animator;
    private bool isMove;


    



    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMove", isMove);
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //Reset MovedDelta
        moveDelta = new Vector3(x, y, 0);
        //Swap sprites direction, whether you're going right or left
        if (moveDelta.x > 0)
        {
            
            isMove = true;
        }

        else if (moveDelta.x < 0)
        {
            isMove = true;
        }
        else if (moveDelta.y != 0)
        {
          
            isMove = true;
        }
        else
        {
          
            isMove = false;
        }

        //Make sure we can move in this direction, by casting a box there first, if the box return null, we free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Make this thing move 
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Make this thing move 
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
