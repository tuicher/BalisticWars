using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    [SerializeField] private GameObject earth;


    [SerializeField] private bool clockTurn = false;
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private float speed;
    [SerializeField] private float radio;

    private Vector3 pos;
    
    private void Awake()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
        rgbd = GetComponent<Rigidbody2D>();

        pos = transform.position;

        radio = (earth.transform.position - pos).magnitude;

        pos = pos.normalized;
    }

    private void Update()
    {
        pos = transform.position.normalized;
        RotateAroundEarth(Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        /*
        var aux = earth.transform.position - transform.position;
        var dir = new Vector2(aux.y ,-aux.x);
        rgbd.velocity = dir.normalized * speed;
        */
    }

    private void RotateAroundEarth(float alpha)
    {
        if (clockTurn)
        {
            alpha = -alpha;
        }
        
        var sin = Mathf.Sin(alpha * Mathf.Deg2Rad);
        var cos = Mathf.Cos(alpha * Mathf.Deg2Rad);
        
        transform.position = new Vector3((cos * pos.x) - (sin * pos.y),
                (sin * pos.x) + (cos * pos.y), 0) * radio;

        var upDir = transform.position - earth.transform.position;
        transform.up = upDir;
    }
}
