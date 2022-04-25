using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;

    private void OnEnable()
    {
        EventManager.onGameStart += GameStartEvent;
        EventManager.onPlayerCaught += PlayerCaughtEvent;
    }

    private void OnDisable()
    {
        EventManager.onGameStart -= GameStartEvent;
        EventManager.onPlayerCaught -= PlayerCaughtEvent;

    }
    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
    }

    void GameStartEvent()
    {
        playerAnimator.SetBool("isStarted", true);
    }
    void PlayerCaughtEvent()
    {
        playerAnimator.Play("Fall");
    }
}
