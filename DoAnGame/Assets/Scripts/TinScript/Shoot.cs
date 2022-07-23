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

    

    private string SHOTGUN = "shotgun", THOMPSON = "thompson", MINER = "miner", BAZOOKA = "bazooka", PISTOL = "pistol"  ;

    // truong
    SpellCoolDownCicle spell;
        
    //


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        

        // truong
        spell = FindObjectOfType<SpellCoolDownCicle>();

        //

    }
    void Update()
    {
      
        coolDown -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && coolDown <= 0f)
        {
            
            DoShoot();
            coolDown = coolDownLap;

            // truong
                spell.coolDownLap(coolDownLap);

            //

        }
    }

   

    public void DoShoot()
    {
        //Shake
        CinemachineShake.Instance.ShakeCamera(0.5f, 0.2f);

        //Create bullet
        if(transform.gameObject.name == SHOTGUN)
        {

            for (int i = 0; i <= 5; i++)
            {
                Vector3 shortGunFlyingDirection = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
                CreateBullet(shortGunFlyingDirection, 3, 0.7f);
            }
          
        }
        else
        {
            CreateBullet( Vector3.zero, 0, 3f);
        }

        audioSource.Play();
        //Recoil
        transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(firePoint.right * -recoilForce, ForceMode2D.Force);
        
    }


    private void CreateBullet(Vector3 flyingDirection, float drag, float destroyTime)
    { 
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rbShortGun = bullet.GetComponent<Rigidbody2D>();
        rbShortGun.AddForce((firePoint.right + flyingDirection) * (bulletForce), ForceMode2D.Impulse);
        rbShortGun.drag = drag;
        Destroy(bullet, destroyTime);
    }
}
