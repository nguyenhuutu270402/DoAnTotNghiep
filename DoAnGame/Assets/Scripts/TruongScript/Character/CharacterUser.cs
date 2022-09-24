
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class CharacterUser : MonoBehaviour
{
    private Animator animator;
    private int selectedOption = 0;

    // list trnag phục tốn tiền
    [Header("Character Buy")]
    public List<RuntimeAnimatorController> CharacterBuy = new List<RuntimeAnimatorController>();
    // list trang phuc cua user
    [Header("Character User")]
    public List<RuntimeAnimatorController> PlayerUser = new List<RuntimeAnimatorController>();
    // list trang phuc cua user tính theo điểm
    [Header("Character Point")]
    public List<RuntimeAnimatorController> PlayerPoints = new List<RuntimeAnimatorController>();


    private List<RuntimeAnimatorController> characters;
    private int Points;


    public static CharacterUser Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        characters = new List<RuntimeAnimatorController>();
        Points = PlayerPrefs.GetInt("UserPoints");
        Debug.Log(Points + "");
        characters.AddRange(PlayerUser);
        addPlayerPoints();
        addPlayerBuy();
    }
    public void updteCharacter(int _skin)
    {
        if (_skin == 7)
        {
            characters.Add(CharacterBuy[0]);
        }
        if (_skin == 8)
        {
            characters.Add(CharacterBuy[1]);
        }

    }

    private void addPlayerPoints()
    {
        if (Points >= 350)
        {
            characters.Add(PlayerPoints[0]);
            characters.Add(PlayerPoints[1]);
            characters.Add(PlayerPoints[2]);
        }else if(Points >= 250)
        {
            characters.Add(PlayerPoints[0]);
            characters.Add(PlayerPoints[1]);
        }else if(Points >= 150)
        {
            characters.Add(PlayerPoints[0]);
        }
    }
    private void addPlayerBuy()
    {
        int skin1 = PlayerPrefs.GetInt("skin1");
        int skin2 = PlayerPrefs.GetInt("skin2");
        if (skin1 == 7 || skin2 == 7)
        {
            characters.Add(CharacterBuy[0]);
        }
        if (skin1 == 8 || skin2 == 8)
        {
            characters.Add(CharacterBuy[1]);
        }
    }
    void Start()
    {   
        animator = gameObject.GetComponent<Animator>();
        
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            selectedOption = PlayerPrefs.GetInt("selectedOption");
            animator.runtimeAnimatorController = characters[selectedOption] as RuntimeAnimatorController;
        }
    }
    void Update()
    {
    }
    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characters.Count)
        {
            selectedOption = 0;
        }
        saveOption();
    }
    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characters.Count - 1;
        }
        saveOption();
    }
    private void saveOption()
    {
        animator.runtimeAnimatorController = characters[selectedOption] as RuntimeAnimatorController;
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

}
