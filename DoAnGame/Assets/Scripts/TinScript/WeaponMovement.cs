using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    Vector3 difference;
    public float rotationZ;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        //get mouse position
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //rotate our weapon
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (rotationZ < -90 || rotationZ > 90)
        {

            transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
        }

        if (difference.x < 0)
        {
            //Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Player.GetComponent<SpriteRenderer>().flipX = true;

        }

        else
        {
            //Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
            Player.GetComponent<SpriteRenderer>().flipX = false;
        }

    }
}
