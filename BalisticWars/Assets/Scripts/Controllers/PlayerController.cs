using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float angle = 0.0f;
    [SerializeField] private float scrollSpeed;


    [SerializeField] public const float GRAVITY = -4.9f;


    private void Awake()
    {
        // initialize component
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SetRotation();
    }

    void SetRotation()
    {
        var aux = Input.GetAxis("Mouse ScrollWheel");
        if (aux != 0)
        {
            angle += scrollSpeed * aux;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
}
