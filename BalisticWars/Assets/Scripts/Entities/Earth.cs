using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Earth : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private int degPerChunk;
    [SerializeField] private GameObject chunk;
    [SerializeField] private List<GameObject> chuckList;

    private void Awake()
    {
        GenerateChunks();
    }

    private Biome GetBiome(string s)
    {
        switch (s)
        {
            case "w":
                return Biome.Woods;
            case "s":
                return Biome.Sea;
            case "d":
                return Biome.Desert;
            default:
                return Biome.Woods;
        }
    }
    
    private void LoadChunks(string input)
    {
        var splited = input.Split(';');
        var index = 0;
        foreach (var s in splited)
        {
            var b = GetBiome(s);
            chuckList[index].GetComponent<Chunk>().SetBiome(b);
            index++;
        }
    }
    private void GenerateChunks()
    {
        chuckList = new List<GameObject>();
        for (int i = 0; i < 360; i+=degPerChunk)
        {
            
            var pos = Vector3.up * radio;
            var q = Quaternion.Euler(0, 0, i);
            pos = q * pos;

            chuckList.Add(Instantiate(chunk, pos, q, transform));
        }
        LoadChunks("s;s;s;s;s;s;s;s;s;s;s;s;s;s;s;s;s;s;s;s;d;d;s;s;s;s;w;w;w;w;w;w;w;w;w;w;w;w;w;w;w;w;s;s;s;s;s;s;w;w;w;w;w;w;w;w;w;w;w;w");
        //LoadChunks("w;w;w;w;w;w;w;w;s;s;s;s;s;s;d;d;w;w;w;d;d;d;s;s;s;s;w;w;w;w;w;w;w;w;w;w;w;w;w;w;w;w;s;s;s;s;s;s;w;w;w;w;w;w;w;w;w;w;w;w");
    }
}
