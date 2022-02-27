using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Earth : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private GameObject chunk;
    [SerializeField] private int degPerChunk;

    private void Awake()
    {
        for (int i = 0; i < 360; i+=degPerChunk)
        {
            
            var pos = Vector3.up * radio;
            var q = Quaternion.Euler(0, 0, i);
            pos = q * pos;

            Instantiate(chunk, pos, q, transform);
        }
       
    }
}
