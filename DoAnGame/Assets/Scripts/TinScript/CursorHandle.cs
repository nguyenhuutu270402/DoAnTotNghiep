using UnityEngine;

public class CursorHandle : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private CursorMode cursorMode = CursorMode.Auto;
    [SerializeField] private Vector2 hotSpot;


    void Start()
    {
        //This script still dirty
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    
}
