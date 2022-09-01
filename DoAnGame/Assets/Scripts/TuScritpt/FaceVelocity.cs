using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class FaceVelocity : MonoBehaviour
{
    public AILerp EnemyAIPath;
    Vector2 direction;
    Animator animator;
    public GameObject EnemyGameObject, explosion;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();

    }

    void faceVelocity()
    {
        direction = EnemyAIPath.velocity;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }


    public void deadEnemy()
    {
        Destroy(EnemyGameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void changeAnimatorNormal()
    {
        animator.SetBool("Hurt", false);
    }


}
