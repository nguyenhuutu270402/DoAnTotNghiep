using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class BossRandom : MonoBehaviour
{
    public List<GameObject> Positionboss = new List<GameObject>();
    public List<GameObject> bosss = new List<GameObject>();
    public GameObject PositionBoss;
    private int LengthChild_PositionBoss = 0;

    private int PreviousPosition; // hi?n t?i
    private int CurrentPosition = -1;  // tr??c ?ó

    private int PreviousBoss; // hi?n t?i
    private int CurrentBoss = -1;  // tr??c ?ó

    public GameObject Depot; // n?i ch?a boss


    public GameObject spawningOnSceneBoss;

    [Header("Intro UI")]
    [SerializeField] private GameObject introPanel;
    [SerializeField] private GameObject topBorder;
    [SerializeField] private GameObject bottomBorder;
    [SerializeField] private Text nameOfBoss;
    [SerializeField] private Image avatar;

    [Header("Boss's Avatar")]
    [SerializeField] private Sprite popCorn;
    [SerializeField] private Sprite cagedShit;
    [SerializeField] private Sprite umbrella;
    [SerializeField] private Sprite darkBruh;
    [SerializeField] private Sprite skullGod;








    public static BossRandom Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LengthChild_PositionBoss = PositionBoss.transform.childCount;
        for (int i = 0; i < LengthChild_PositionBoss; i++)
        {
            Positionboss.Add(PositionBoss.transform.GetChild(i).gameObject);
        }

        if (introPanel.activeInHierarchy)
        {
            introPanel.SetActive(false);
        }
    }



    public void RandomBossAndPosition()
    {
        CurrentPosition = PreviousPosition;
        PreviousPosition = Random.Range(0, Positionboss.Count - 1);
        while (CurrentPosition == PreviousPosition)
        {
            PreviousPosition = Random.Range(0, Positionboss.Count - 1);
        }
        Vector3 position = Positionboss[PreviousPosition].transform.position;

        CurrentBoss = PreviousBoss;
        PreviousBoss = Random.Range(0, bosss.Count - 1);
        while (CurrentBoss == PreviousBoss)
        {
            PreviousBoss = Random.Range(0, bosss.Count - 1);
        }
        GameObject boss = Instantiate(bosss[PreviousBoss], position, Quaternion.identity);
        spawningOnSceneBoss = boss;
        boss.transform.parent = Depot.transform;
        

    }

    public void PlayIntro()
    {
        introPanel.SetActive(true);
        nameOfBoss.text = spawningOnSceneBoss.tag;
        avatar.GetComponent<Image>().sprite = AvaterHandle();
        Invoke("MoveOutXPos", 0.8f);
        Invoke("DeactivePanel", 1.3f);

        MoveInXPos(nameOfBoss.gameObject, 0, 0.5f);
        MoveInXPos(topBorder, 0, 0.4f);
        MoveInXPos(bottomBorder, 0, 0.4f);
        MoveInXPos(avatar.gameObject, 0, 0.2f);
    }

    void MoveInXPos(GameObject gameObject, int pos, float time)
    {
        gameObject.LeanMoveLocalX(pos, time);
    }
    void MoveOutXPos()
    {
        nameOfBoss.gameObject.LeanMoveLocalX(1920, 0.5f);
        topBorder.LeanMoveLocalX(-1920, 0.5f);
        bottomBorder.LeanMoveLocalX(1920, 0.5f);
        avatar.gameObject.LeanMoveLocalX(-1920, 0.5f);
        
    }

    void DeactivePanel()
    {
        introPanel.SetActive(false);
    }

    private Sprite AvaterHandle()
    {
        Sprite temp = null;
        if(spawningOnSceneBoss.CompareTag("Boss_UmbrellaDarkKnight"))
        {
            temp = umbrella;

        }

        else if(spawningOnSceneBoss.CompareTag("Boss_SkullGod"))
        { 
            temp = skullGod;
        }

        else if (spawningOnSceneBoss.CompareTag("Boss_GiantMutantBeetle"))
        {
            temp = cagedShit;

        }

        else if (spawningOnSceneBoss.CompareTag("Boss_TheTreeHusketeers"))
        { 
            temp = popCorn;
        }

        else if (spawningOnSceneBoss.CompareTag("Boss_DarkSideDino"))
        {

            temp = darkBruh;
        }
        return temp;
    }

    private void ResetIntro()
    {
        
    }
}
