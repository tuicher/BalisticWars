using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprtRenderer;
    [SerializeField] private Transform pivot;

    [SerializeField] private Color chunkColor;


    private void Awake()
    {
        pivot = transform.GetChild(0);
    }
}
