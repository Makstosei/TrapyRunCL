using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterHangTrigger : MonoBehaviour
{
    public GameObject refObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "PlayerFinish")
        {
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Animator>().Play("Hang");
            other.transform.parent = refObject.gameObject.transform;
            EventManager.Instance.GameEnded();
            GetComponent<Animation>().Play();
        }
    }
}
