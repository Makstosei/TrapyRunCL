using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    bool updateposition;
    Vector3 targetposition;
    GameObject playerref;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.tag = "PlayerFinish";
            gameObject.GetComponent<BoxCollider>().enabled = false;
            EventManager.Instance.FinishLine();
            updateposition = true;
            playerref = other.gameObject;
            other.GetComponent<Animator>().SetFloat("Direction", 0.5f);
        }
    }




}
