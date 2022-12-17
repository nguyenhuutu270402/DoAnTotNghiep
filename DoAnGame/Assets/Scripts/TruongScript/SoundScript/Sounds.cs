using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    private AudioSource m_sound;
    public Slider SFX_Scrollbar, BGM_Scrollbar;
    public int index;
    private float SFX_Scrollbar_Value, SFX_befor;
    private float BGM_Scrollbar_Value, BGM_befor;
    void Start()
    {   
        float[] sound = JsonManager.Instance.getSounds();// 0 : SFX // 1 : BGM
        m_sound = GetComponent<AudioSource>();
        SFX_Scrollbar.value = sound[0];
        SFX_befor = sound[0];
        BGM_Scrollbar.value = sound[1];
        BGM_befor = sound[1];
        m_sound.volume = sound[1];
        
    }
    void Update()
    {
        SFX_Scrollbar_Value = SFX_Scrollbar.value;
        if (SFX_Scrollbar_Value != SFX_befor)
        {
            SFX_befor = SFX_Scrollbar_Value;
            JsonManager.Instance.updateSounds(SFX_Scrollbar_Value, 0);

            // truyền volume SFX vào click
            SoundsClick.Instance.volue(SFX_Scrollbar_Value);
            if(index == 0)
            {
                Shoot.Instance.volue(SFX_Scrollbar_Value);
                StoreBullet.Instance.volue(SFX_Scrollbar_Value);
                Melee.Instance.volue(SFX_Scrollbar_Value);
                BossRandom.Instance.volue(SFX_Scrollbar_Value);
                BombScript.Instance.volue(SFX_Scrollbar_Value);
            }
            
        }
        BGM_Scrollbar_Value = BGM_Scrollbar.value;
        if (BGM_Scrollbar_Value != BGM_befor)
        {
            BGM_befor = BGM_Scrollbar_Value;
            JsonManager.Instance.updateSounds(BGM_Scrollbar_Value, 1);
        }


        m_sound.volume = BGM_Scrollbar_Value;
    }
    //public void playSound(string _file)
    //{
    //    m_sound.PlayOneShot(Resources.Load<AudioClip>("Sounds/" + _file));
    //}
}
