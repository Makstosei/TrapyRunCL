using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public float forwardSpeed;
    private Animator playerAnimator;

    private void OnEnable()
    {
        EventManager.onGameStart += GameStartEvent;
        EventManager.onGameEnded+= PlayerCaughtEvent;
        EventManager.onPlayerCaught += PlayerCaughtEvent;
    }
    private void OnDisable()
    {
        EventManager.onGameStart -= GameStartEvent;
        EventManager.onPlayerCaught -= PlayerCaughtEvent;
        EventManager.onGameEnded -= PlayerCaughtEvent;
    }

    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    void PlayerCaughtEvent()
    {
        forwardSpeed = 0;    
    }

    void GameStartEvent()
    {
        forwardSpeed = 4.5f;
    }

    void Update()
    {
        
    }
}
