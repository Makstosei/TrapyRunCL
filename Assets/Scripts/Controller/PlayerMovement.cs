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
    public int maxSideMovement;
    public bool isGameStarted;
    public float forwardSpeed;
    public bool canRotate;
    private bool resetposition;

    private void OnEnable()
    {
        EventManager.onGameStart += GameStartEvent;
        EventManager.onGameEnded += EndGameEvent;
        EventManager.onFinshLine += FinshLineEvent;
    }

    private void OnDisable()
    {
        EventManager.onGameStart -= GameStartEvent;
        EventManager.onGameEnded -= EndGameEvent;
        EventManager.onFinshLine -= FinshLineEvent;
    }

    void GameStartEvent()
    {
        forwardSpeed = 4.5f;
        resetposition = false;
    }
    void FinshLineEvent()
    {
        canRotate = false;
        resetposition = true;
    }

    void EndGameEvent()
    {
        forwardSpeed = 0;
        this.enabled = false;
    }
    void Start()
    {
        canRotate = true;
        roadSpawner = FindObjectOfType<RoadSpawner>();
        GetComponentInChildren<Animator>().SetFloat("Direction", 0.5f);
    }

    void Update()
    {

        if (resetposition)
        {
            float x = Mathf.Lerp(gameObject.transform.position.x, 0, sideSpeed * 3 * Time.deltaTime);

            gameObject.transform.position = new Vector3(x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        }
        else
        {
            MoveCheck();
        }
    }

    void MoveCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stopTouch = false;
            firstPressPos = Input.mousePosition;
            if (!isGameStarted)
            {
                isGameStarted = true;
                EventManager.Instance.GameStart();
            }
        }

        if (Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
            Vector2 Distance = firstPressPos - currentPos;
            if (!stopTouch)
            {
                if (Distance.x < -swipeRange && canRotate)
                {
                    MoveLeft();
                }
                else if (Distance.x > swipeRange && canRotate)
                {
                    MoveRight();
                }
                else
                {
                    gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
                    direction = 0.5f;
                    GetComponentInChildren<Animator>().SetFloat("Direction", direction);
                }


            }
        }
        else
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
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



    void MoveLeft()
    {
        float x = (transform.position.x + sideSpeed * 5 * Time.deltaTime);
        float sideMovement = Mathf.Clamp(x, -maxSideMovement, maxSideMovement);
        gameObject.transform.position = new Vector3(sideMovement, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        direction = Mathf.Clamp(direction += 2 * Time.deltaTime, 0, 1);
        GetComponentInChildren<Animator>().SetFloat("Direction", direction);
    }
    void MoveRight()
    {
        float x = (transform.position.x - sideSpeed * 5 * Time.deltaTime);
        float sideMovement = Mathf.Clamp(x, -maxSideMovement, maxSideMovement);
        gameObject.transform.position = new Vector3(sideMovement, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        direction = Mathf.Clamp(direction -= 2 * Time.deltaTime, 0, 1);
        GetComponentInChildren<Animator>().SetFloat("Direction", direction);
    }
}
