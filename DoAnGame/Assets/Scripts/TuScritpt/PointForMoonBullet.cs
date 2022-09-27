using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForMoonBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public Rigidbody2D rigidbody;
    GameObject player;
    Vector2 moveDirection;
    float timeLoop = 0.5f;
    public GameObject effectMoon;


    void Start()
    {
        Destroy(gameObject, 10f);
        player = GameObject.FindWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(moveDirection.x * Speed, moveDirection.y * Speed);
        transform.right = new Vector2(moveDirection.x, moveDirection.y);
        timeLoop -= Time.deltaTime;
        if(timeLoop <= 0 )
        {
            Instantiate(effectMoon, transform.position, Quaternion.identity);
            timeLoop = 0.5f;
        }
    }
}
