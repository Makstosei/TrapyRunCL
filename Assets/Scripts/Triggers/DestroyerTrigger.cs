using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (other.transform.parent.tag == "Enemy"|| other.transform.parent.tag == "SmartEnemy")
        {
            other.transform.parent.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(other.transform.parent.gameObject,1f);
        }
       
    }
}
