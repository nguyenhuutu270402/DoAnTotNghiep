using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemWeb : MonoBehaviour
{
    private int id;
    public GameObject Dino;
    public GameObject Confirm;
    public DatabaseCharacter DB;
    public static BuyItemWeb Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyItem(int _id)
    {
        id = _id;
    }
    public void ConfirmWeb()
    {
        Confirm.SetActive(false);
        Dino.SetActive(true);
        Debug.Log("mua thành công rồi nhhe");
        DB.BuyID(id);
        CHPlay.Instance.updateCharacter();
    }
}
