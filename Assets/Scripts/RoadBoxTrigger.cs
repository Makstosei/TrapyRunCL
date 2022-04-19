using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBoxTrigger : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            Destroy(gameObject, 2f);
        }
    }
}
