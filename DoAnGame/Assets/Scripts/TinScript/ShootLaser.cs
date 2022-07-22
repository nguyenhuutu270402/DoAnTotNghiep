using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{

    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    public Vector2 fieldOfImpact;
    public LayerMask LayerToHit;
    public GameObject Effect;
    public float force;
    private AudioSource audioSource;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //audioSource.Play();
            m_lineRenderer.enabled = true;
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
            GameObject effect =  Instantiate(Effect,_hit.point, Quaternion.identity);
            if(_hit.transform.gameObject.tag == "Enemies")
            {
                
                Vector2 direction = _hit.transform.position - transform.position;
                _hit.transform.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force);
                Destroy(_hit.transform.gameObject, 1f);
            }
            
            Destroy(effect, 0.25f);
            
           

        }
        else
        {
            //Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
            //audioSource.Pause();
            m_lineRenderer.enabled = false;
           

        }

        }
    void Shoot(){
        if (Physics2D.Raycast(m_transform.position, transform.right) )
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
            Instantiate(Effect, laserFirePoint.position, Quaternion.identity);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }
    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

    void hitEnemy()
    {
        Collider2D[] objects = Physics2D.OverlapBoxAll(transform.position, fieldOfImpact, LayerToHit);
        foreach(Collider2D obj in objects)
        {
            //audioSource.Play();
            if (obj.gameObject.tag == "Enemies")
            {
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
                Destroy(obj.gameObject, 1f);
            }
            GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
        }
    }
}
