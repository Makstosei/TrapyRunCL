using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemiesToSpawn;
    Transform parentTransform;
    Transform playerRef;
    private bool isGameEnded;

    private void OnEnable()
    {
        EventManager.onGameStart += GameStartEvent;
        EventManager.onGameEnded += GameEndEvent;
        EventManager.onPlayerCaught += GameEndEvent;
    }

    private void OnDisable()
    {
        EventManager.onGameStart -= GameStartEvent;
        EventManager.onGameEnded -= GameEndEvent;
        EventManager.onPlayerCaught -= GameEndEvent;
    }


    void Start()
    {
        parentTransform = GameObject.Find("Enemies").transform;
        playerRef = GameObject.Find("Player").transform;
    }

    void GameStartEvent()
    {
        StartCoroutine(SpawnEnemies());
    }

    void GameEndEvent()
    {
        isGameEnded = true;
    }


    IEnumerator SpawnEnemies()
    {
        for (int i = 1; i < 10; i++)
        {
            int x = Random.Range(0, EnemiesToSpawn.Count);
            GameObject spawnedEnemy = Instantiate(EnemiesToSpawn[x], parentTransform);
            float randomizez = Random.RandomRange(6, 8);
            Vector3 spawnPosition = new Vector3(-4 + 1 * i, 0.5f, playerRef.position.z -randomizez);
            spawnedEnemy.transform.position = spawnPosition;
            spawnedEnemy.GetComponent<NavMeshMove>().gameStarted = true;
        }
        yield return new WaitForSecondsRealtime(3f);
       
        if (!isGameEnded)
        {
            StartCoroutine(SpawnEnemies());
        }
    }




}
