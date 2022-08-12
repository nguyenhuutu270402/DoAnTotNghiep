using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponChest : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public GameObject Player;
    public GameObject TextObject;

    private float time = 0.7f;
    private float _time = 0.00001f;
    private Vector3 v = new Vector3(2f, 2f, 0);
    private Vector3 _v = new Vector3(1f, 1f, 0);

    public static WeaponChest Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    // vị trí ban đầu Vector2 ( 960 , -340) -340f == 200f 
    void Start()
    {
        Text.text = "";
    }
    public void intdexWeapon(int index)
    {
        
        Text.text = Player.transform.GetChild(index).transform.gameObject.name;
        LeanTween.moveY(TextObject, 800f, time / 2).setOnComplete(() =>
        {
            LeanTween.scale(TextObject, v , time).setOnComplete(() =>
            {
                Text.text = "";
                LeanTween.moveY(TextObject, 200f, _time);
                LeanTween.scale(TextObject, _v, _time);
            });
        });
    }
}
