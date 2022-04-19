using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public int forwardSpeed;
   
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime) ;
    }
}
