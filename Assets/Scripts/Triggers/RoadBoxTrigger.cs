using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RoadBoxTrigger : MonoBehaviour
{
    public int speed = 1;
    private bool updatecolor;
    private float starttime;
    private bool isBoxFall;
    public BoxCollider ObstacleCollider;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !isBoxFall)
        {
            isBoxFall = true;
            starttime = Time.time;
            updatecolor = true;
            GetComponent<BoxCollider>().enabled = false;
            gameObject.AddComponent<Rigidbody>();
            gameObject.isStatic = false;
        }
        if (other.tag == "SmartEnemy")
        {
            if (isBoxFall&&other.gameObject.GetComponent<EnemySimpleMove>().canJump)
            {
                other.GetComponent<EnemySimpleMove>().JumpOneBox();
            }
            else
            {
                other.gameObject.GetComponent<EnemyJumpTrigger>().enabled = false;
            }
        }
        if (other.tag == "Enemy" && isBoxFall)
        {
        }


    }


    private void Update()
    {
        if (updatecolor)
        {
            float t = (Time.time - starttime) * speed;
            GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, Color.red, t);
        }
    }



}
