using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Biome
{
    Woods,
    Sea,
    Desert
};

public class Chunk : MonoBehaviour
{
    
    private Color GetColor (Biome b)
    {
        switch (b)
        {
            case Biome.Woods:
                return Color.green;
            case Biome.Sea:
                return Color.cyan;
            case Biome.Desert:
                return Color.yellow;
            default:
                return Color.magenta;
        }
    }

    public void SetBiome(Biome b)
    {
        gameObject.tag = b.ToString();
        var c = GetColor(b);
        gameObject.GetComponent<SpriteRenderer>().color = c;
    }

}
