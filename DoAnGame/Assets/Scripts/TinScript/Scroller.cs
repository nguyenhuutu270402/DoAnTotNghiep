using UnityEngine.UI;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float posX, posY;
    
    private void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(posX, posY) * Time.deltaTime, background.uvRect.size);
    }

}
