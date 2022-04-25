using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterRotor : MonoBehaviour
{
  

    void Update()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, gameObject.transform.forward, 5f);
    }
}
