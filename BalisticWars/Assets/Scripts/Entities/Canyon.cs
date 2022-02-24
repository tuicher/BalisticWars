using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Canyon : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [Space] [SerializeField] private Vector2 direction;
    [SerializeField] private float angle;
    [SerializeField] private float rotation;
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
        GetDegRotation();
    }
    
    void Update()
    { 
        rotation = Input.GetAxis("Horizontal");
        if (rotation != 0)
        {
            pivot.Rotate(Vector3.back, rotation * rotationSpd);
            GetDegRotation();
            CalculateShoot();
        }

        if (Input.GetButtonDown("Fire1"))
            Shoot();
        
        
    }

    private void Shoot()
    {
        var aux = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        var a = new Vector2(transform.position.x, transform.position.y);
        var b = new Vector2(aux.x, aux.y);
        var dir = b - a;
        
        var pro = Instantiate(proyectile, pivot.position, Quaternion.identity);
        pro.GetComponent<BalisticProyectile>().SetInitialValues(dir.normalized, dir.magnitude * proyectileForce);
    }

    private void GetDegRotation()
    {
        angle = pivot.localRotation.eulerAngles.z;
    }

    private Vector3 GetVelocity(float t)
    {
        return pivot.up.normalized * (proyectileForce - PlayerController.gravity * t);
    }
    private Vector3 GetPosition(float t)
    {
        return pivot.position + GetVelocity(t);
    }

    private void CalculateShoot()
    {
        int j = 0;
        for (float i = 0; i < previsualizationSteps; i+=0.1f)
        {
            var aux = GetPosition(i);
            lineRenderer.SetPosition(j, aux);
            j++;
        }
    }
}
