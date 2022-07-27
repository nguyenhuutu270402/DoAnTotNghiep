using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCoolDownCicle : MonoBehaviour
{
    [SerializeField] private Image ImgCooldown;
    private bool isCollDown = false;
    private float CollDownTime;
    private float CollDownTimer = 0.0f;

    void Start()
    {
        ImgCooldown.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if(isCollDown == true)
        {
            CollDownTimer -= Time.deltaTime;
            ImgCooldown.fillAmount = CollDownTimer / CollDownTime;
            if (CollDownTimer < 0.0f)
            {
                ImgCooldown.fillAmount = 0.0f;
                CollDownTimer = 0.0f;
                isCollDown = false;
            }
        }
    }
    

    // lấy time hồi bên shoot
    public void coolDownLap(float time)
    {
        CollDownTime = time;
        if(time > 0.6f)
        {
            isCollDown = true;
            CollDownTimer = CollDownTime;
            ImgCooldown.fillAmount = 1;
        }
    }


}
