using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public float time = 3f;
    public Slider slider;
    private float _time = 0f;

    public Animator animator;
    public GameObject play;
    private bool isMove = true;

    public GameObject dust;
    private float dust_coolDown = 0;
    private float dust_coolDownlap = 0.2f;


    void Start()
    {
        animator.SetBool("isMove", isMove);
        LeanTween.moveX(play, 8f, time);

        dust_coolDown = dust_coolDownlap;
    }
    void Update()
    {
        _time += Time.deltaTime;
        slider.value = _time / time;
        if (time - _time <= 0)
        {
            SceneManager.LoadScene(2);
        }

        dust_coolDown -= Time.deltaTime;
        if (dust_coolDown <= 0)
        {
            GameObject TheDust = Instantiate(dust, play.transform.position, Quaternion.identity);
            Destroy(TheDust, 0.6f);
            dust_coolDown = dust_coolDownlap;
        }
    }



}
