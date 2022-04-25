using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    #region Singleton

    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<EventManager>();
            return _instance;
        }
    }
    #endregion

    public static Action onGameStart;
    public static Action onGameEnded;
    public static Action onFinshLine;
    public static Action onPlayerCaught;
     
    public void GameStart()
    {
        onGameStart.Invoke();
    }

    public void GameEnded()
    {
        onGameEnded.Invoke();
    }
    public void PlayerCaught()
    {
        onPlayerCaught.Invoke();
    }
    public void FinishLine()
    {
        onFinshLine.Invoke();
    }
}
