using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class FaceVelocityBossDarkSideDino : MonoBehaviour
{
    public AILerp EnemyAIPath;
    Vector2 direction;
    Animator animator;
    public GameObject EnemyGameObject, explosion;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();

    }

    void faceVelocity()
    {
        float sp = EnemyAIPath.speed;
        animator.SetFloat("Speed", sp);

        direction = (player.transform.position - transform.position).normalized;
        if (direction.x >= 0)
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
        GameObject expls = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(expls, 0.25f);
    }

    public void changeAnimatorNormal()
    {
        animator.SetBool("Hurt", false);
    }
}
