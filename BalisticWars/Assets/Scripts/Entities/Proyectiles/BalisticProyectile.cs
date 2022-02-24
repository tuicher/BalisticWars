using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental;
using UnityEngine;

public class BalisticProyectile : MonoBehaviour
{
    [SerializeField] private Transform myTrans;
    [SerializeField] private GameObject earth;
    [Space]
    [SerializeField] private Vector2 initialV;
    [SerializeField] private float force;
    [Space] 
    [SerializeField] private float timeToSnap;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private List<Vector3> posList;
    [SerializeField] private float count = 0;
    
    private void Awake()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
        myTrans = gameObject.GetComponent<Transform>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void Start()
    {
        earth.GetComponent<PlayerController>().AddAttracted(gameObject);
    }

    private void Update()
    {
        GetPosList();
        DrawLine();
    }

    void GetPosList()
    {
        count += Time.deltaTime;
        if (count >= timeToSnap)
        {
            count = 0;
            var v = transform.position;
            posList.Add(v);
        }
    }
    
    void DrawLine(){
        
        lineRenderer.positionCount = posList.Count + 1;

        for (int i = 0; i < posList.Count; i++)
        {
            lineRenderer.SetPosition(i,posList[i]);
        }
        lineRenderer.SetPosition(posList.Count, gameObject.transform.position);
        
    }

    public void SetInitialValues(Vector2 v, float f)
    {
        initialV = v;
        force = f;
        gameObject.GetComponent<Rigidbody2D>().velocity = initialV * force;
    }
}
