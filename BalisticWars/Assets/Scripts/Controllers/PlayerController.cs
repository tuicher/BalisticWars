using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float scrollSpeed;

    [SerializeField] public const float GRAVITY = -4.9f;
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
    public void AddAttracted(GameObject toAttract)
    {
        Debug.Log("Added: ", toAttract);
        attracted.Add(toAttract);
    }
}
