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


    // truong
    SpellCoolDownCicle spell;
    //


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coolDown = coolDownLap;


        // truong
        spell = FindObjectOfType<SpellCoolDownCicle>();

        float[] sound = JsonManager.Instance.getSounds();// 0 : SFX // 1 : BGM
        audioSource.volume = sound[0];
        //

    }
    void Update()
    {
      
        coolDown -= Time.deltaTime;
        if(Input.GetKey(KeyCode.Mouse0) && coolDown <= 0f && Time.timeScale != 0)
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

           CinemachineShake.Instance.ShakeCamera(0.5f, 0.1f);
           //CinemachineShake.Instance.ShakeCamera(5f, 1f);


        //Create bullet

        switch (transform.gameObject.name)
        {
            case "shotgun":
                for (int i = 0; i <= 5; i++)
                {
                    Vector3 shortGunFlyingDirection = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
                    CreateBullet(shortGunFlyingDirection, 3, 0.7f);
                }

                break;
            case "miner":
                CreateBullet(Vector3.zero, 0, 1000f);
                break;
                    
            default:
                CreateBullet(Vector3.zero, 0, 3f);
                break;
        }
        //if(transform.gameObject.name == SHOTGUN)
        //{

            //for (int i = 0; i <= 5; i++)
            //{
            //    Vector3 shortGunFlyingDirection = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
            //    CreateBullet(shortGunFlyingDirection, 3, 0.7f);
            //}
          
        //}
        //else
        //{
        //    CreateBullet( Vector3.zero, 0, 3f);
        //}

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

    // truong
    public static Shoot Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void volue(float volume)
    {
        audioSource.volume = volume;
    }


    //
}
