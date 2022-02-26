using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class BalisticProyectile : MonoBehaviour
{
    [SerializeField] private GameObject earth;
    [SerializeField] private GameObject graphics;
    [SerializeField] private Rigidbody2D rgbd;
    [Space]
    [SerializeField] private Vector2 initialV;
    [SerializeField] private float force;
    [SerializeField] private bool flying;
    [Space] 
    [SerializeField] private float count = 0;
    [SerializeField] private Material rndMat;
    private void Awake()
    {
        
        earth = GameObject.FindGameObjectWithTag("Earth");

        rgbd = GetComponent<Rigidbody2D>();

        var c = new Color(Random.value, Random.value,Random.value, 1f);

        rndMat.color = c;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = c;
    }

    private void Start()
    {
        earth.GetComponent<PlayerController>().AddAttracted(gameObject);
    }

    private void FixedUpdate()
    {
        if (flying)
            CalculateAtraction();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        flying= false;
        rgbd.velocity = Vector2.zero;
        rgbd.angularVelocity = 0.0f;
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(graphics);  
    }

    void CalculateAtraction()
    {
        var aux = earth.transform.position - transform.position;
        var dir = new Vector2(aux.x, aux.y);
        
        rgbd.velocity -= dir.normalized * PlayerController.GRAVITY;
    }

    public void SetInitialValues(Vector2 v, float f)
    {
        initialV = v;
        force = f;
        gameObject.GetComponent<Rigidbody2D>().velocity = initialV * force;
    }
    
    
}
