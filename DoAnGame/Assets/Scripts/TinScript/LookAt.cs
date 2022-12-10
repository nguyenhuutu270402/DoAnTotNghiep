using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{   
    Camera cam;
    Transform player;
    [SerializeField] float threshold;
    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        player = FindObjectOfType<Player>().gameObject.transform;
    }
    void Update()
    {
        try
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 targetPos = (player.position + mousePos) / 2;

            targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
            targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);

            this.transform.position = targetPos;
        }
        catch (System.Exception)
        {

        }
    }
}
