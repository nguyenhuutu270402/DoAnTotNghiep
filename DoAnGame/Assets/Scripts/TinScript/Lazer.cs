using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;

    private void LateUpdate()
    {
        //m_lineRenderer.enabled = true;
        RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
        Draw2DRay(laserFirePoint.position, _hit.point);
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
