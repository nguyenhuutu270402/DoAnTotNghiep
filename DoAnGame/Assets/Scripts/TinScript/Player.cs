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
    private int PickupWeapon = 2, HoldingWeapon = 2;


    // truong
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    //


    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        Cam = GameObject.FindWithTag("MainCamera");
        transform.GetChild(2).gameObject.SetActive(true);
 
        // truong
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        updateCharacter(selectedOption);



        //
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMove", isMove);
        
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
        if(collision.gameObject.name == "chest_0")
        {


            //PickupWeapon = Random.Range(3, 8);
            while(PickupWeapon == HoldingWeapon)
            {
                PickupWeapon = Random.Range(3, 8);
            }
            transform.GetChild(HoldingWeapon).transform.gameObject.SetActive(false);
            transform.GetChild(PickupWeapon).transform.gameObject.SetActive(true);
            
            if (PickupWeapon == 7)
            {
                Cam.GetComponent<Volume>().weight = 1;
            }
            else
            {
                Cam.GetComponent<Volume>().weight = 0;

            }

            ChestRandom.Instance.RandomPosition();

            HoldingWeapon = PickupWeapon;
        }
    }



    // truong
    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.CharacterSprite;
        animator.runtimeAnimatorController = character.animation as RuntimeAnimatorController;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    //
}
