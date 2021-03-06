using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSideMovementTrigger : MonoBehaviour
{
    public int maxSideMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.GetComponent<PlayerMovement>().maxSideMovement = maxSideMovement;
        }
    }
}
