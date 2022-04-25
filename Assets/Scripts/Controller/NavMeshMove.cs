using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Vector3 destination;
    public GameObject playerRef;
    public bool gameStarted, checkStop;

    private void OnEnable()
    {
        playerRef = GameObject.Find("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        EventManager.onGameStart += GameStartEvent;
    }

    private void OnDisable()
    {
        EventManager.onGameStart -= GameStartEvent;

    }

    void GameStartEvent()
    {
        gameStarted = true;
    }

    private void Start()
    {
        playerRef = GameObject.Find("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (gameStarted)
        {
            if (navMeshAgent.velocity == Vector3.zero&&checkStop)
            {
                navMeshAgent.enabled = false;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z +3 * Time.deltaTime);
            }
            if(navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.speed= 7 + (playerRef.transform.position.z - gameObject.transform.position.z);
                destination = gameObject.transform.position + gameObject.transform.forward * 0.5f;
                navMeshAgent.destination = destination;
            }
        }
        if (navMeshAgent.velocity != Vector3.zero)
        {
            checkStop = true;
        }

    }


    void MoveAI()
    {

    }


}
