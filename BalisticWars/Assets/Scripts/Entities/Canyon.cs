using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Canyon : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform earth;
    [Space] 
    [SerializeField] private Vector2 direction;
    [SerializeField] private float angle;
    [SerializeField] private Vector3 shootAngle;
    [SerializeField] private float rotationSpd;
    [Space] 
    [SerializeField] private GameObject proyectile;
    [SerializeField] private float proyectileForce;
    [Space]
    [SerializeField] private int previsualizationSteps;
    [SerializeField] private List<Vector2> prev;
    [SerializeField] private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        earth = GameObject.FindGameObjectWithTag("Earth").GetComponent<Transform>();
        GetDegRotation();
    }
    
    void Update()
    { 
        var rotation = Input.GetAxis("Horizontal");
        if (rotation != 0)
        {
            pivot.Rotate(Vector3.back, rotation * rotationSpd);
            GetDegRotation();
            CalculateShoot();
        }

        var potencer = Input.GetAxis("Vertical");
        if (potencer > 0)
        {
            proyectileForce+=0.1f;
            CalculateShoot();
        } else if (potencer < 0)
        {
            proyectileForce-=0.1f;
            CalculateShoot();
        }
        

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
            Shoot();
        
        
    }

    private void Shoot()
    {
        //var aux = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //var a = new Vector2(transform.position.x, transform.position.y);
        //var b = new Vector2(aux.x, aux.y);
        //var dir = b - a;
        
        var pro = Instantiate(proyectile, pivot.position, Quaternion.identity);
        pro.GetComponent<BalisticProyectile>().SetInitialValues(pivot.right, proyectileForce * 6.8f);
    }

    private void GetDegRotation()
    {
        angle = pivot.localRotation.eulerAngles.z;
    }

    private void CalculateShoot()
    {
        lineRenderer.positionCount = previsualizationSteps;
        Vector3 a = Vector3.zero; 
        Vector3 v = pivot.right * proyectileForce; 
        Vector3 p = pivot.position;
        lineRenderer.SetPosition(0, p);
        for (int i = 1; i < previsualizationSteps; i++)
        {
            a = (earth.position - p).normalized * PlayerController.GRAVITY;
            v -= a;
            p += v;
            lineRenderer.SetPosition(i, p);
        }
    }
}
