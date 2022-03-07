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

    Vector2 RotateVector2D(Vector2 v, float alpha)
    {
        var sin = Mathf.Sin(alpha * Mathf.Deg2Rad);
        var cos = Mathf.Cos(alpha * Mathf.Deg2Rad);
            
        return new Vector2((cos * v.x) - (sin * v.y),(sin * v.x) + (cos * v.y));
    }
    void SetRotation()
    {
        var aux = Input.GetAxis("Mouse ScrollWheel");
        if (aux != 0)
        {
            var angleRot = scrollSpeed * aux;
            angle += angleRot;
            foreach (var proyectile in GameObject.FindGameObjectsWithTag("Proyectile"))
            {
                proyectile.GetComponent<Rigidbody2D>().velocity =
                    RotateVector2D(proyectile.GetComponent<Rigidbody2D>().velocity, angleRot);
            }
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
}
