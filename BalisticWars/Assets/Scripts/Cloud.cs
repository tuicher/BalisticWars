using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cloud : MonoBehaviour
{
    [SerializeField] private List<Sprite> spr;

    private void Awake()
    {
        var s = spr[Random.Range(0,spr.Count-1)];
        gameObject.GetComponent<SpriteRenderer>().sprite = s;
    }
}
