using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool stopTouch;
    private Vector3 secondPressPos;
    private Vector3 firstPressPos;
    private Vector3 currentPos;
    public int swipeRange;
    public float tapRange;
    public float sideSpeed;
    RoadSpawner roadSpawner;
    public float direction;

    void Start()
    {
        roadSpawner = FindObjectOfType<RoadSpawner>();
        GetComponentInChildren<Animator>().SetFloat("Direction", 0.5f);
    }

    void Update()
    {
        MoveCheck();
    }

    void MoveCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stopTouch = false;
            firstPressPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
            Vector2 Distance = firstPressPos - currentPos;
            if (!stopTouch)
            {
                if (Mathf.Abs(Distance.x) >= Mathf.Abs(Distance.y))
                {
                    if (Distance.x < -swipeRange)
                    {
                        float x = (transform.position.x + sideSpeed * 5 * Time.deltaTime);
                        float sideMovement = Mathf.Clamp(x, -roadSpawner.roadWidth / 2 * 1f + 1 * 1f, -roadSpawner.roadWidth / 2 * 1f + roadSpawner.roadWidth * 1f);
                        gameObject.transform.position = new Vector3(sideMovement, transform.position.y, transform.position.z);
                        direction = Mathf.Clamp(direction += 10 * Time.deltaTime, 0, 1);
                        GetComponentInChildren<Animator>().SetFloat("Direction", direction);
                    }
                    else if (Distance.x > swipeRange)
                    {
                        float x = (transform.position.x - sideSpeed * 5 * Time.deltaTime);
                        float sideMovement = Mathf.Clamp(x, -roadSpawner.roadWidth / 2 * 1f + 1 * 1f, -roadSpawner.roadWidth / 2 * 1f + roadSpawner.roadWidth * 1f);
                        gameObject.transform.position = new Vector3(sideMovement, transform.position.y, transform.position.z);
                        direction = Mathf.Clamp(direction -= 10 * Time.deltaTime, 0, 1);
                        GetComponentInChildren<Animator>().SetFloat("Direction", direction);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            stopTouch = true;
            secondPressPos = Input.mousePosition;
            Vector2 Distance = secondPressPos - firstPressPos;
            direction = 0.5f;
            GetComponentInChildren<Animator>().SetFloat("Direction", direction);
        }
    }
}
