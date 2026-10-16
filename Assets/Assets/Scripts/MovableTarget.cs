using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MovableTarget : MonoBehaviour
{
    [SerializeField] private UI ui;
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [SerializeField] private float speed;
    [SerializeField] private int pointsGetFucked;
    [SerializeField] private int nuhUh;
    [SerializeField] private GameObject breakableLittleTarget;
    
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        StartCoroutine(MoveTarget());
    }

    private IEnumerator MoveTarget()
    {
        
        while (true)
        {
            while (transform.position != b.transform.position)
            {
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, b.transform.position, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(1);
        
            while (transform.position != a.transform.position)
            {
                rb.transform.position = Vector3.MoveTowards(rb.transform.position, a.transform.position, speed * Time.deltaTime);
                yield return null;
            }
        
            yield return new WaitForSeconds(1);
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("red")) ui.UpdateUI(pointsGetFucked);
        else if (CompareTag("notRed") && meshRenderer.enabled)
        {
            ui.UpdateUI(nuhUh);
            var sTarget = Instantiate(breakableLittleTarget, transform.position, transform.rotation); 
            Destroy(sTarget, 3);
            meshRenderer.enabled = false;
            StartCoroutine(ReenableMeshRenderer());
        }
    }
    
    IEnumerator ReenableMeshRenderer()
    { ;
        yield return new WaitForSeconds(3);
        meshRenderer.enabled = true;
    }


}
