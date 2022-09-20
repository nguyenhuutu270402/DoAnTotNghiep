using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    public static Muzzle Instance { get; private set; }

    private Animator anim;

    private bool isMuzzle = false;



    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("isMuzzle", isMuzzle);
        if (isMuzzle == true)
        {
            Debug.Log("muzzle");
            anim.Play("muzzle");
        }
         
        isMuzzle = false;
    }


    public void PlayMuzzle()
    {
        isMuzzle = true;
    }
}
