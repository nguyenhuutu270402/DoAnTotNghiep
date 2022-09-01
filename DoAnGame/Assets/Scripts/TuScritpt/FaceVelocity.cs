using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class FaceVelocity : MonoBehaviour
{
    public AILerp EnemyAIPath;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

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
}
