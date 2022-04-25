using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemySimpleMove : MonoBehaviour
{
    public float forwardSpeed;
    Transform playerRef;
    public bool canMove = true;
    public bool canJump = true;

    private void OnEnable()
    {
        EventManager.onPlayerCaught += PlayerCaughtEvent;
    }

    private void OnDisable()
    {
        EventManager.onPlayerCaught -= PlayerCaughtEvent;

    }

    void PlayerCaughtEvent()
    {
        canMove = false;
        GetComponentInChildren<Animator>().SetBool("isStarted", false);
        StartCoroutine(IdleRandomizer());
    }





    private void Start()
    {
        float direction = 0.5f;
        GetComponentInChildren<Animator>().SetFloat("Direction", direction);
        playerRef = GameObject.Find("Player").transform;
        GetComponentInChildren<Animator>().SetBool("isStarted", true);
    }
    void Update()
    {
        if (canMove)
        {
            forwardSpeed = 5 + (playerRef.transform.position.z - gameObject.transform.position.z) * 1 / 3;
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        }
    }

    IEnumerator IdleRandomizer()
    {
        float random = Random.Range(0, 0.5f);
        yield return new WaitForSecondsRealtime(random);
        GetComponentInChildren<Animator>().Play("Cheer");
    }

    public IEnumerator KickJump()
    {
        
            Vector3 jumpPosition = new Vector3(playerRef.transform.position.x, playerRef.transform.position.y, playerRef.transform.position.z + 1f);
            gameObject.transform.DOJump(jumpPosition, 1, 1, 1);
            gameObject.GetComponentInChildren<Animator>().Play("Kick");
            playerRef.GetComponentInChildren<Animator>().Play("Fall");
            EventManager.Instance.GameEnded();
            yield return new WaitForSecondsRealtime(0.8f);
         
    }
    public void StartKickJump()
    {
        StartCoroutine(KickJump());
    }

    public IEnumerator JumpOneBox()
    {
        Debug.Log("jumponebox");
        Vector3 jumpEndPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 2);
        gameObject.transform.DOJump(jumpEndPosition, 0.5f, 1, 0.5f);
        yield return new WaitForSecondsRealtime(0.5f);
    }
}
