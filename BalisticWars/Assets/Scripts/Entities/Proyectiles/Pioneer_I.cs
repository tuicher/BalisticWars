using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pioneer_I : MonoBehaviour
{
    [SerializeField] private GameObject earth;
    [Space]
    [SerializeField] private Vector2 initialV;
    [SerializeField] private float force;

    public void SetInitialValues(Vector2 v, float f)
    {
        initialV = v;
        force = f;
        gameObject.GetComponent<Rigidbody2D>().velocity = initialV * force;
    }
    
    private void Awake()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
    }

    private void Start()
    {
        earth.GetComponent<BWController>().AddAttracted(gameObject);
    }
}
