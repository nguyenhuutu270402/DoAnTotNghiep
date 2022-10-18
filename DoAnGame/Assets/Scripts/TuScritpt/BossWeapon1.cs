using UnityEngine;

public class BossWeapon1 : MonoBehaviour
{
    GameObject player;
    Vector2 moveDirection;
    Vector3 transformStart;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transformStart = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();
    }

    void faceVelocity()
    {
        moveDirection = (player.transform.position - transform.position).normalized;
        if(moveDirection.x >= 0)
        {
            transform.localScale = transformStart;
            transform.right = moveDirection;
        }
        else
        {
            //spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1 * transformStart.x, transformStart.y, transformStart.z);
            transform.right = moveDirection * -1;
        }
    }
}
