using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpTrigger : MonoBehaviour
{
    public bool hasJumped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!hasJumped)
            {
                hasJumped = true;       
                gameObject.GetComponent<EnemySimpleMove>().StartKickJump();
            }
         
        }
    }



}
