using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    AudioSource m_sound;
    public AudioClip _sound;
    public Slider SFX_Scrollbar, BGM_Scrollbar;
    public int index;
    private float SFX_Scrollbar_Value, SFX_befor;
    private float BGM_Scrollbar_Value, BGM_befor;
    void Start()
    {
        float[] sound = JsonManager.Instance.getSounds();// 0 : SFX // 1 : BGM
        m_sound = GetComponent<AudioSource>();
        m_sound.clip = _sound;
        m_sound.Play();



        // seting volume 
        if (index == 0)
        {
            SFX_Scrollbar.value = sound[0];
            m_sound.volume = sound[0];
            SFX_befor = sound[0];
        }
        else if (index == 1)
        {
            BGM_Scrollbar.value = sound[1];
            m_sound.volume = sound[1];
            BGM_befor = sound[1];
        }

    }
    void Update()
    {
        SFX_Scrollbar_Value = SFX_Scrollbar.value;
        if (SFX_Scrollbar_Value != SFX_befor)
        {
            SFX_befor = SFX_Scrollbar_Value;
            JsonManager.Instance.updateSounds(SFX_Scrollbar_Value, 0);
            SoundsClick.Instance.volue(SFX_Scrollbar_Value);
        }
        BGM_Scrollbar_Value = BGM_Scrollbar.value;
        if (BGM_Scrollbar_Value != BGM_befor)
        {
            BGM_befor = BGM_Scrollbar_Value;
            JsonManager.Instance.updateSounds(BGM_Scrollbar_Value, 1);
        }


        if (index == 0)
        {
            m_sound.volume = SFX_Scrollbar_Value;
        }
        else if (index == 1)
        {
            m_sound.volume = BGM_Scrollbar_Value;
        }
    }
}