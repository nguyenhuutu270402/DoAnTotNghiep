using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class SetOpenWeapon : MonoBehaviour
{
    private int M00_0 = 0;
    private int StartM00_0 = 0;
    private List<int> arr = new List<int>();
    public int Scene;
   
    private void Awake()
    {
        M00_0 = PlayerPrefs.GetInt("M00_0");
        StartM00_0 = M00_0;
        arr.Clear();
        arr.Add(PlayerPrefs.GetInt("OpenWeapon_1"));
        arr.Add(PlayerPrefs.GetInt("OpenWeapon_2"));
        arr.Add(PlayerPrefs.GetInt("OpenWeapon_3"));
        arr.Add(PlayerPrefs.GetInt("OpenWeapon_4"));
        arr.Add(PlayerPrefs.GetInt("OpenWeapon_5"));
        arr.Add(PlayerPrefs.GetInt("OpenWeapon_6"));
    }
    void Start()
    {
        if(Scene == 1)
        {
            Debug.Log(MaxWeapon(arr, M00_0) + " check M00_0");
            PlayerPrefs.SetInt("maxWeapon", MaxWeapon(arr, M00_0));
        }
    }
    void Update()
    {
        M00_0 = PlayerPrefs.GetInt("M00_0");
        if (M00_0 != StartM00_0)
        {
            Debug.Log("da cap nhat M00_0 and maxWeapon trong SetOpenWeapon");
            PlayerPrefs.SetInt("maxWeapon", MaxWeapon(arr, M00_0));
            StartM00_0 = M00_0;
        }
        Debug.Log(MaxWeapon(arr, M00_0) + " max Weapon");
    }
    public int MaxWeapon(List<int> _arr, int _M00_0)
    {
        int maxWeapon = 3;
        for (int i = _arr.Count - 1; i >= 0; i--)
        {
            if( _M00_0 >= _arr[i])
            {
                Debug.Log(arr[i] + " index" + i);
                maxWeapon += i + 2;
                return maxWeapon;
            }
        }
        return maxWeapon;
    }
}
