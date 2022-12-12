using UnityEngine;

public class RotateAtStart : MonoBehaviour
{
    void Start()
    {
        transform.gameObject.LeanScale(new Vector3(50, 50, 50), 0.15f);
        transform.gameObject.LeanRotateZ(0, 0.15f);
    }

}
