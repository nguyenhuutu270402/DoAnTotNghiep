using UnityEngine;

public class ChestRandom : MonoBehaviour
{
   
    public static ChestRandom Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void RandomPosition()
    {
        transform.position = new Vector3( Random.Range(0.5f, 3.7f), Random.Range(3, 1.3f), 0f);
    }
}
