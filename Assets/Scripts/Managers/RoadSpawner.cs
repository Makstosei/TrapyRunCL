using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadLeft, roadMiddle, roadRight;
    public int roadLenght, roadWidth, roadNarrowingDistance, NarrowingLenght;

    void Start()
    {
        roadLenght += 10;
        SpawnRoad();
    }

   

    void SpawnRoad()
    {
        for (int roadLenghtId = 1; roadLenghtId < roadLenght+1; roadLenghtId++)
        {
            for (int roadWidthId = 1; roadWidthId < roadWidth+1; roadWidthId++)
            {
                GameObject newSpawnedObject;
                if (roadWidthId == 1)
                {
                    newSpawnedObject = Instantiate(roadLeft);
                }
                else if (roadWidthId == roadWidth)
                {
                    newSpawnedObject = Instantiate(roadRight);
                }
                else
                {
                    newSpawnedObject = Instantiate(roadMiddle);
                }
                Vector3 spawnPosition = new Vector3((-roadWidth/2*1f + roadWidthId* 1f),0,roadLenghtId* 1f - 10f);
                newSpawnedObject.transform.position = spawnPosition;
                newSpawnedObject.transform.parent = gameObject.transform;
                newSpawnedObject.isStatic = true;
            }

        }





    }


}
