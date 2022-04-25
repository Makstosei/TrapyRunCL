using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCaughtTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.tag = "Untagged";
            EventManager.Instance.PlayerCaught();
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
