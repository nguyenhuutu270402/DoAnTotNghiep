using UnityEngine;

public class TransformAtStart : MonoBehaviour
{
    [SerializeField] float posX;
    void Start()
    {
        transform.gameObject.LeanMoveLocalX(posX, 0.3f);  
    }
}
