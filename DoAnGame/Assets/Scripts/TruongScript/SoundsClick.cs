using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsClick : MonoBehaviour
{
    AudioSource m_sound_click;
    public AudioClip _sound_click;
    void Start()
    {
        m_sound_click = GetComponent<AudioSource>();
        m_sound_click.clip = _sound_click;

        float[] sound = JsonManager.Instance.getSounds();// 0 : SFX // 1 : BGM
        m_sound_click.volume = sound[0];
    }

    // Update is called once per frame
    void Update()
    {
        //float[] sound = JsonManager.Instance.getSounds();// 0 : SFX // 1 : BGM
        //m_sound_click.volume = sound[0];
        //Debug.Log(sound[0] + "aaa");
    }
    public void click()
    {
        m_sound_click.Play();
    }
    public static SoundsClick Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void volue(float volume) {
        m_sound_click.volume = volume;
    }
}
