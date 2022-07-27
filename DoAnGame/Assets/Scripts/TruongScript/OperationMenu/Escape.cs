using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [SerializeField] GameObject MenuPresent;
    [SerializeField] GameObject MenuBefore;
    void Update()
    {
        // thoát menu bằng cách nhân ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuBefore.SetActive(true);
            MenuPresent.SetActive(false);
            SoundsClick.Instance.click();
        }
    }
}
