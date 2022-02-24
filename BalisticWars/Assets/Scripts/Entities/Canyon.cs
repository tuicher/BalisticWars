using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Canyon : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [Space]
    [SerializeField] private float angle;
    [SerializeField] private float rotation;
    [SerializeField] private float rotationSpd;
    [SerializeField] private float proyectileForce;
    [Space] 
    [SerializeField] private GameObject proyectile;
    
    private void Awake()
    {
        GetDegRotation();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        rotation = Input.GetAxis("Horizontal");
        if (rotation != 0)
        {
            pivot.Rotate(Vector3.back, rotation * rotationSpd);
            GetDegRotation();
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
        pro.GetComponent<Pioneer_I>().SetInitialValues(dir.normalized, dir.magnitude * proyectileForce);
    }

    private void GetDegRotation()
    {
        angle = pivot.localRotation.eulerAngles.z;
    }
}
