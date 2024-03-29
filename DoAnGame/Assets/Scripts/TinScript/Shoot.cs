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
    public float accurate;

    [SerializeField] private WeaponMovement weaponMovement;



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

        //Muzzle 
        Muzzle.Instance.PlayMuzzle();

        //Create bullet

        switch (transform.gameObject.name)
        {
            case "Shotgun":
                for (int i = 0; i <= 7; i++)
                {
                    Vector3 shortGunFlyingDirection = new Vector3(Random.Range(-accurate, accurate), Random.Range(-accurate, accurate), 0);
                    CreateBullet(shortGunFlyingDirection, 3, 0.8f);

                    ShootAnimation(30, 0.2f);

                }

                break;
            case "Miner":
                CreateBullet(Vector3.zero, 0, 1000f);
                break;

            case "Uzi":
                Vector3 smgFlyingDirection = new Vector3(Random.Range(-accurate, accurate), Random.Range(-accurate, accurate), 0);
                CreateBullet(smgFlyingDirection, 0, 3f);
                break;

            case "AssaultRifle":
                StartCoroutine(CreateThreeBullet());
                break;

            case "Crossbow":
                CreateBullet(Vector3.zero, 0, 7f);
                break;

            default:
                CreateBullet(Vector3.zero, 0, 7f); 
                ShootAnimation(20, 0.1f);
                break;
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
    private IEnumerator CreateThreeBullet()
    {
        int count = 0;

        while (count < 3)
        {
            CreateBullet(Vector3.zero, 0, 3f);
            yield return new WaitForSeconds(0.07f);
            count++;
        }
    }

    private void ShootAnimation(float add, float time)
    {
        // check weapon's rotation so you can rotation when shoot in right way
        if (weaponMovement != null)
        {
            if (weaponMovement.rotationZ < -90 || weaponMovement.rotationZ > 90)
            {
               // transform.LeanRotateAround(Vector3.forward, -30, 0.1f); // rotate a little bit when shoot
                transform.LeanRotateAround(Vector3.forward, -add, time); // rotate a little bit when shoot
            }
            else
            {
                //transform.LeanRotateAround(Vector3.forward, 30, 0.1f); // rotate a little bit when shoot
                transform.LeanRotateAround(Vector3.forward, add, time); // rotate a little bit when shoot
            }
        }
    }
 
}
