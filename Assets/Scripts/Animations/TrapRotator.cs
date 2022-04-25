using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotator : MonoBehaviour
{
    float randomize;
    private void Start()
    {
        randomize = Random.Range(1, 4);
    }

    void Update()
    {
        
        gameObject.transform.RotateAround(gameObject.transform.position, gameObject.transform.up, randomize);
    }
}
