using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera playerChase, heliChase;

    private void OnEnable()
    {
        EventManager.onGameEnded += GameEndEvent;
    }

    private void OnDisable()
    {
        EventManager.onGameEnded -= GameEndEvent;
    }



    void GameEndEvent()
    {
        playerChase.Priority=1 ;
        heliChase.Priority = 10;
    }
}
