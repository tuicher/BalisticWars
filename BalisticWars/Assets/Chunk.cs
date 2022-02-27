using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Color continent;
    [SerializeField] private Color ocean;

    private void Awake()
    {
        var chunkColor = continent;
        if (Random.value > 0.5f)
        {
            chunkColor = ocean;
        }
        gameObject.GetComponent<SpriteRenderer>().color = chunkColor;
    }
}
