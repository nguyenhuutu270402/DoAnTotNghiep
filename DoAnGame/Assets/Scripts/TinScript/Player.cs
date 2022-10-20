using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private Vector3 moveDelta;
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;

    private Animator animator;
    private bool isMove;
    private GameObject Cam;
    private int PickupWeapon = 10 , HoldingWeapon = 10;

    public GameObject dust;
    private float dust_coolDown = 0;
    private float dust_coolDownlap = 0.2f;

    private int price_boss = 0;

    private int maxWeapon = 3;

    void Start()
    {
        dust_coolDown = dust_coolDownlap;

        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        Cam = GameObject.FindWithTag("MainCamera");
        transform.GetChild(10).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        dust_coolDown -= Time.deltaTime;
        animator.SetBool("isMove", isMove);

        maxWeapon = PlayerPrefs.GetInt("maxWeapon");
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //Reset MovedDelta
        moveDelta = new Vector3(x, y, 0);
        //Swap sprites direction, whether you're going right or left
        if (moveDelta.x > 0 || moveDelta.x < 0 || moveDelta.y != 0)
        {
            isMove = true;
            if(dust_coolDown <= 0)
            {
                GameObject TheDust = Instantiate(dust, transform.position, Quaternion.identity);
                Destroy(TheDust, 0.6f);
                dust_coolDown = dust_coolDownlap;
            }
        }
        else
        {
            isMove = false;
        }

        //Make sure we can move in this direction, by casting a box there first, if the box return null, we free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Make this thing move 
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //Make this thing move 
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }


    // COLLISION WITH THE CHEST
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "chest_0" || collision.gameObject.name == "chest_Boss_0")
        {   
            //PickupWeapon = Random.Range(3, 8);
            while (PickupWeapon == HoldingWeapon)
            {
                PickupWeapon = Random.Range(0, maxWeapon);
            }
            transform.GetChild(HoldingWeapon).transform.gameObject.SetActive(false);
            transform.GetChild(PickupWeapon).transform.gameObject.SetActive(true);

                // truong

            WeaponChest.Instance.intdexWeapon(PickupWeapon);
            ScorePlayer.Instance.IncreaseScore();

                // 
            ChestRandom.Instance.RandomPosition();

            HoldingWeapon = PickupWeapon;
            if (collision.gameObject.name == "chest_Boss_0")
            {
                price_boss += Random.Range(1, 3);
                PlayerPrefs.SetInt("PriceBoss", price_boss);
                Debug.Log(price_boss + " PriceBoss");
                Destroy(collision.gameObject);
                ArrowChest.Instance.setactive();
            }
            
        }
    }



    //if (PickupWeapon == 7)
    //{
    //    Cam.GetComponent<Volume>().weight = 1;
    //}
    //else
    //{
    //    Cam.GetComponent<Volume>().weight = 0;

    //}


}
