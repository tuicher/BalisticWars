using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float scrollSpeed;

    [SerializeField] public const float gravity = -4.9f;
    [SerializeField] private List<GameObject> attracted;


    private void Awake()
    {
        // initialize component
        mainCamera = Camera.main;
        attracted = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        var aux = Input.GetAxis("Mouse ScrollWheel");
        if (aux != 0)
        {
            mainCamera.orthographicSize -= aux * scrollSpeed;
        }
    }

    private void FixedUpdate()
    {
        UpdateAttracted();
    }

    public void AddAttracted(GameObject toAttract)
    {
        Debug.Log("HOLA");
        attracted.Add(toAttract);
    }

    void UpdateAttracted()
    {
        foreach (var att in attracted)
        {
            var a_trans = att.transform;
            var aux = transform.position - a_trans.position;
            var dir = new Vector2(aux.x, aux.y);

            var a_rgbd = att.GetComponent<Rigidbody2D>();
            a_rgbd.velocity -= dir.normalized * gravity;
        }
    }
}
