using UnityEngine;

public class StoreBullet : MonoBehaviour
{
    private float coolDown;
    public float coolDownLap;

    public int storeBullet;
    private int bulletNumber = 6;
    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float bulletForce;
    private AudioSource audioSource;

    SpellCoolDownCicle spell;
    void Start()
    {
        storeBullet = bulletNumber;
        coolDown = 0;
        audioSource = GetComponent<AudioSource>();
        spell = FindObjectOfType<SpellCoolDownCicle>();
    }


    void Update()
    {
        coolDown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale != 0 && coolDown <= 0)
        {

            //Shake
            CinemachineShake.Instance.ShakeCamera(0.5f, 0.1f);
            audioSource.Play();
            CreateBullet(Vector3.zero, 0, 3f);

            if (storeBullet <= 0)
            {
                coolDown = coolDownLap;
                spell.coolDownLap(coolDownLap);
                storeBullet = bulletNumber;
            }


        }
    }

    private void CreateBullet(Vector3 flyingDirection, float drag, float destroyTime)
    {
        //Muzzle 
        Muzzle.Instance.PlayMuzzle();
        GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rbShortGun = bullet.GetComponent<Rigidbody2D>();
        rbShortGun.AddForce((firePoint.right + flyingDirection) * (bulletForce), ForceMode2D.Impulse);
        rbShortGun.drag = drag;
        Destroy(bullet, destroyTime);
        storeBullet--;
    }

}
