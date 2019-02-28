using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Sprite[] objects;
    private int random;

    void Start()
    {
        random = Random.Range(0, objects.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
