using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public DatabaseCharacter DB;
    public TextMeshProUGUI IDText;
    private int ID;
    private Characters characters;

    public GameObject Dino;
    public GameObject Confirm;
    public TextMeshProUGUI TextConfirm;
    
    public void Buy()
    {
        ID = int.Parse(IDText.text.Trim());
        Debug.Log(ID + "");
        characters = DB.GetCharacter(ID);
        if(characters.Buy == false)
        {
            Debug.Log(ID + " có thể mua");
            Confirm.SetActive(true);
            Dino.SetActive(false);
            TextConfirm.text = "you definitely want to use " + characters.Price + " RP to buy a" + characters.CharacterName;
            BuyItemWeb.Instance.BuyItem(ID);
        }
        else if(characters.Buy == true)
        {
            Debug.Log(ID + " đã mua");
        }
    }
    
}
