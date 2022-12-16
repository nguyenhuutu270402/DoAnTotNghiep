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


        // truong
        float[] sound = JsonManager.Instance.getSounds();// 0 : SFX // 1 : BGM
        audioSource.volume = sound[0];
        //
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
            transform.LeanRotateAround(Vector3.forward, 30, 0.1f); // rotate a little bit when shoot

            if (storeBullet <= 0)
            {
                coolDown = coolDownLap;
                spell.coolDownLap(coolDownLap);
                transform.LeanRotateAround(Vector3.forward, 300, 0.3f); // rotate when reload
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
    // truong
    public static StoreBullet Instance { get; private set; }

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
