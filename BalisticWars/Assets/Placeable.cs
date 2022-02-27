using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    [SerializeField] private GameObject earth;


    void Start()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
        SetOrientation();   
    }

    private void Update()
    {
        SetOrientation();
    }

    void SetOrientation()
    {
        var dir = transform.position - earth.transform.position;
        dir.z = 0;
        transform.up = dir;
    }
}
