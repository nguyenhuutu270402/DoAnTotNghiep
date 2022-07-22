using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float coolDown = 0;
    public float coolDownLap;
    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float bulletForce;
    private AudioSource audioSource;
    public float recoilForce;

    //public Sprite sprites; private SpriteRenderer weapon;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //weapon = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    weapon.sprite = sprites;
        //    Debug.Log(">>>>>>>>>");
        //}


        coolDown -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && coolDown <= 0f)
        {
            DoShoot();
            coolDown = coolDownLap;
        }
    }

    public void DoShoot()
    {
        //coolDownLap = 0.7f;
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        audioSource.Play();
        //Recoil
        transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(firePoint.right * -recoilForce, ForceMode2D.Force);

    }
}
