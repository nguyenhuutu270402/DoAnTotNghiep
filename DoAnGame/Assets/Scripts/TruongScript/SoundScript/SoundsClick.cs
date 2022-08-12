using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsClick : MonoBehaviour
{
    AudioSource m_sound_click;
    void Start()
    {
        m_sound_click = GetComponent<AudioSource>();

        float[] sound = JsonManager.Instance.getSounds();// 0 : SFX // 1 : BGM
        m_sound_click.volume = sound[0];
    }
    public void click()
    {

        playSound("button");
    }
    public static SoundsClick Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void volue(float volume) {
        m_sound_click.volume = volume;
    }
    public void playSound(string _file)
    {
        m_sound_click.PlayOneShot(Resources.Load<AudioClip>("Sounds/" + _file));
    }
}
